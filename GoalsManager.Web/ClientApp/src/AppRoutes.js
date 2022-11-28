import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Calendar } from './components/Calendar';
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
      path: '/calendar',
      element: <Calendar />
  },
  ...ApiAuthorzationRoutes
];

export default AppRoutes;
