import { List, ListItem, ListItemText } from "@mui/material";
import Typography from "@mui/material/Typography";
import axios from "axios";
import { useEffect, useState } from "react";

function App() {
  const title = 'Welcome to Reactivities';
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5000/api/activities/GetActivities')
      .then(response => setActivities(response.data))
      
    return () => { };
  }, []);

  return (
    <>
      <Typography variant="h3" gutterBottom>{title}</Typography>
      <List>
        {
          activities.map((activity: Activity) => (
            <ListItem key={activity.id}>
              <ListItemText>{activity.title}</ListItemText>
            </ListItem>
          ))
        }
      </List>
    </>
  )
}

export default App
