using Duende.IdentityServer.EntityFramework.Options;
using GoalsManager.DataAccess;
using GoalsManager.Web.Controllers;
using GoalsManager.Web.Tests.Mocking;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GoalsManager.Web.Tests.Controllers
{
    internal class TaskControllerTests
    {
        private void RecreateDatabase()
        {
            CreateContext().Database.EnsureDeleted();
        }


        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ControllerTaskDB")
                .Options;

            var context = new ApplicationDbContext(options, new TestOperationalStoreOptions());
            return context;
        }

        private TaskController CreateController(string username)
        {
            var controller = new TaskController(CreateContext());

            var cp = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                    new(ClaimTypes.Name, username)
                }));

            controller.ControllerContext = new()
            {
                HttpContext = new DefaultHttpContext() { User = cp }
            };

            return controller;
        }

        [SetUp]
        public void Setup()
        {
            RecreateDatabase();
        }

        [Test]
        public void GetTasks_ReturnUserTasks()
        {
            var users = ModelGenerator.CreateUsers(2);
            var task1 = ModelGenerator.CreateTask(users[0]);
            var task2 = ModelGenerator.CreateTask(users[1]);

            using var context = CreateContext();

            context.AddRange(users);
            context.SaveChanges();
            context.Add(task1);
            context.Add(task2);
            context.SaveChanges();

            var controller = CreateController(users[0].UserName!);

            var resp = controller.GetTasks();

            var tasks = JsonConvert.DeserializeObject<List<Task>>(resp);

            Assert.Multiple(() =>
            {
                Assert.That(tasks?.Count, Is.EqualTo(1));

                Assert.That(tasks?.First().Name, Is.EqualTo(task1.Name));

                Assert.That(tasks?.First().Id, Is.EqualTo(task1.Id));
                
                Assert.That(tasks?.First().Id, Is.Not.EqualTo(task2.Id));
                
            });
        }

        [Test]
        public void AddTask_MustAddTaskToDb()
        {
            var user = ModelGenerator.CreateUsers(1)[0];

            var task = ModelGenerator.CreateTask(user);
            task.User = default;
            task.UserId = default;

            using var context = CreateContext();
            context.Add(user);
            context.SaveChanges();

            var controller = CreateController(user.UserName!);

            controller.AddTask(task).Wait();

            using var context1 = CreateContext();
            Assert.Multiple(() =>
            {
                Assert.That(context1.Tasks.First().Id, Is.EqualTo(task.Id));
                Assert.That(context1.Tasks.First().Name, Is.EqualTo(task.Name));
            });
        }

        [Test]
        public void RemoveTask_RemoveUserTask_MustRemoveTaskFromDb()
        {
            var user = ModelGenerator.CreateUsers(1)[0];

            var task = ModelGenerator.CreateTask(user);
            var taskCopy = ModelGenerator.CreateTask(user);

            using var context = CreateContext();
            context.Add(user);
            context.SaveChanges();

            context.Add(task);
            context.SaveChanges();

            taskCopy.Id = task.Id;

            var controller = CreateController(user.UserName!);

            controller.RemoveTask(taskCopy).Wait();

            using var context1 = CreateContext();
            Assert.Multiple(() =>
            {
                Assert.That(context1.Tasks.Any(), Is.False);
            });
        }

        [Test]
        public void RemoveTask_RemoveAnotherUserTask_MustnotRemoveTaskFromDb()
        {
            var user = ModelGenerator.CreateUsers(1)[0];
            var user2 = ModelGenerator.CreateUsers(1)[0];

            var task = ModelGenerator.CreateTask(user);
            var task2 = ModelGenerator.CreateTask(user2);

            using var context = CreateContext();
            context.Add(user);
            context.Add(user2);
            context.SaveChanges();

            context.Add(task);
            context.Add(task2);
            context.SaveChanges();

            var controller = CreateController(user.UserName!);

            controller.RemoveTask(task2).Wait();

            using var context1 = CreateContext();
            Assert.Multiple(() =>
            {
                Assert.That(context1.Tasks.Any(x => x.UserId == user.Id), Is.True);

                Assert.That(context1.Tasks.First(x => x.UserId == user.Id).Id, Is.EqualTo(task.Id));
            });
        }

        [Test]
        public void UpdateTask_MustUpdateTaskInDb()
        {
            var user = ModelGenerator.CreateUsers(1)[0];

            var task = new Task(user, "name 1", "desc 1", DateTime.Now, DateTime.Now);
            task.IsComplete = true;
            task.CompleteDate = DateTime.Now;
            
            var taskCopy = new Task(user, "name 2", "desc 2", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1));
            
            using var context = CreateContext();
            context.Add(user);
            context.SaveChanges();

            context.Add(task);
            context.SaveChanges();

            taskCopy.Id = task.Id;

            var controller = CreateController(user.UserName!);

            controller.UpdateTask(taskCopy).Wait();

            using var context1 = CreateContext();
            Assert.Multiple(() =>
            {
                var dbTask = context1.Tasks.First();

                Assert.That(dbTask.Id, Is.EqualTo(task.Id));

                Assert.That(dbTask.CompleteDate, Is.EqualTo(taskCopy.CompleteDate));
                Assert.That(dbTask.CreationDate, Is.EqualTo(taskCopy.CreationDate));
                Assert.That(dbTask.Deadline, Is.EqualTo(taskCopy.Deadline));
                Assert.That(dbTask.Description, Is.EqualTo(taskCopy.Description));
                Assert.That(dbTask.IsComplete, Is.EqualTo(taskCopy.IsComplete));
                Assert.That(dbTask.Name, Is.EqualTo(taskCopy.Name));
            });
        }
    }
}
