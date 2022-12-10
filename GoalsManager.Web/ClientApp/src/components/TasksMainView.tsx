import React from 'react';
import { useNavigate } from 'react-router-dom';
import RecurringTask from '../Models/RecurringTask';
import Task from '../Models/task';
import { ApplicationRoutes } from '../ApplicationRoutes'

interface TasksMainViewProps {
    tasks: Array<Task>
    recurringTasks: Array<RecurringTask>
}

export const TasksMainView = (props: TasksMainViewProps) => {
    const navigate = useNavigate();

    function redirectToAddView() {
        navigate(ApplicationRoutes.addTask);
    }

    return (<button onClick={redirectToAddView}>Add</button>)
}