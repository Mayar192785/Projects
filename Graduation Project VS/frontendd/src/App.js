import { Routes, Route } from "react-router-dom";
import Login from "./Pages/login"; 
import "./index.css";
import HomePage from "./Pages/Home";
import Uploads from "./Pages/Uploads";
import AuditTrail from "./Pages/AuditTrail";
import Files from "./Pages/Files";
import React from "react";
import EmpHome from "./Pages/EmpHome";
import RequestsAdmin from "./Pages/RequestsAdmin"
import Chartpage from "./Pages/chart";
import Recycle from "./Pages/RecycleBin";
import NotificationPage from "./Pages/Notification";
import UserTablePage from "./Pages/UserTablePage";
import AuditorPage from "./Pages/AuditorHome";
import SignupPage from "./Pages/SignupPage";
import Empboard from "./Pages/EmpDashPage";
import BarChartpage from "./Pages/BarchartPage";

function App() {

  return (

         <Routes>
          <Route path="/" element={<SignupPage />}/>
          <Route path="/login" element={<Login />}/>
          <Route path="/EmpHome" element={<Empboard />}/>
          <Route path="/home" element={<HomePage />}/>
          <Route path="/Uploads" element={<Uploads />}/>
          <Route path="/AuditTrail" element={<AuditTrail />}/>
          <Route path="/Files" element={<Files />}/>
          <Route path="/EmpHome" element={<EmpHome />}/>
          <Route path="/Notification" element={<NotificationPage />}/>
          <Route path="/RequestsAdmin" element={<RequestsAdmin />}/>
          <Route path="/linegraph" element={<Chartpage />}/>
          <Route path="/barchart" element={<BarChartpage />}/>
          <Route path="/RecycleBin" element={<Recycle />}/>
          <Route path="/UserTable" element={<UserTablePage />}/>
          <Route path="/AuditorHome" element={<AuditorPage />}/>
         </Routes>  

      );
    }


export default App;