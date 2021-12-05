import { Route, Routes } from "react-router";
import Welcome from "./Pages/Welcome";
import Users from "./Pages/Users";
import Login from "./Pages/Login";
import { Fragment } from "react";
import Register from "./Pages/Register";
import DoctorPage from "./Pages/DoctorPage";

function App() {
  return (
    <Fragment>
      <Routes>
        <Route path="/users" element={<Users />} />
        <Route path="/welcome" element={<Welcome />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/doctorPage" element={<DoctorPage />} />
      </Routes>
    </Fragment>
  );
}

export default App;
