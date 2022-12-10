import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationRoutes } from './ApplicationRoutes'
import { Calendar } from './components/Calendar';
import { TasksMainView } from './components/TasksMainView';
import { Home } from "./components/Home";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: ApplicationRoutes.calendar,
        element: <Calendar />
    },
    {
        path: ApplicationRoutes.tasks,
        element: <TasksMainView/>
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;
