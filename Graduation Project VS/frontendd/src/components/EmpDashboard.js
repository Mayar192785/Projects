import React from "react";

function Dashboard() {
  return (
    <div className="flex flex-col ml-96 mt-14">
        <div className="w-1/5 bg-gray-900 p-4">
                <ul className="flex flex-col space-y-2">
                <li className="text-white hover:bg-gray-800 px-2 py-2 rounded">
                    Dashboard
                </li> 
                <li className="text-white hover:bg-gray-800 px-2 py-2 rounded">
                    Users
                </li>
                <li className="text-white hover:bg-gray-800 px-2 py-2 rounded">
                    Orders
                </li>
                </ul>  
            </div>

            <div className="flex-1 p-4">
                
                <h2 className="text-2xl font-bold"> Dashboard</h2>
                <p>Some dashboard content.</p>   
            </div>  
            </div>
)
}

export default Dashboard;