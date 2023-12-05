import { Routes, Route } from "react-router-dom";
import HomePage from "../Pages/Home";
function rou(){
  return(
    <Routes>
      <Route path="/home" element={<HomePage />}/>
    </Routes>
  )
}

export default rou;