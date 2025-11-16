import { createBrowserRouter } from "react-router";
import App from "../layout/App";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import ActivityFrom from "../../features/activities/ActivityFrom";
import HomePage from "../../features/home/HomePage";
import ActivityDetail from "../../features/activities/details/ActivityDetail";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            { path: "", element: <HomePage /> },
            { path: "activities", element: <ActivityDashboard /> },
            { path: "activities/:id", element: <ActivityDetail /> },
            { path: "createActivity", element: <ActivityFrom key="create" /> },
            { path: "manage/:id", element: <ActivityFrom /> },

        ]
    }
]);