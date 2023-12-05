import React, { useState, useEffect } from "react";
import {
    Card,
    Input,
    Checkbox,
    Button,
    Typography,
  } from "@material-tailwind/react";

function UserTable() {
  const [users, setusers] = useState([]);
  const [showForm, setShowForm] = useState(false);
  const [filteredusers, setFilteredusers] = useState([]);

  useEffect(() => {
    fetch("http://localhost:3001/users")
      .then((res) => res.json())
      .then((data) => setFilteredusers(data))
      .catch((err) => console.log(err));
  }, []);

  const handleDelete = (user) => {
    // Move the file to the recycle bin
    const moveFileToRecycleBin = require("./DeleteFiles");
    // moveFileToRecycleBin(file.path);

    // Remove the file from the files table
    setusers(users.filter((f) => f !== user));
  };
  const [addState, setaddState] = useState("");

  

  const handleChange = (e) => {
      setaddState({...addState, [e.target.id]: e.target.value})
  }

  const addUser = async () => {
      fetch('http://localhost:3001/addusesr', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ 
            email: addState.email, 
            username: addState.username,
            password: addState.password
        })
      }).then(response => response.json())
      .then(data => {
          const { message } = data;
          alert(message)
      }
      ).catch(error=>alert("Failed to login. Try again later."));
  
  }
  const handleSearch = e => {
    const searchTerm = e.target.value;  
    const filteredusers = users.filter(user => 
      user.toLowerCase().includes(searchTerm.toLowerCase())
    );
    setFilteredusers(filteredusers);
    }  
  const handleSubmit = (e) => {
      e.preventDefault();
      addUser();
  }
  return (
    <div className="flex flex-col ml-96 mt-14">
    <div>
        <div className="flex justify-between py-3 pl-2">
            <div className="relative max-w-xs">
                <label htmlFor="hs-table-search" className="sr-only">
                    Search
                </label>
                <input
                    type="text"
                    name="hs-table-search"
                    id="hs-table-search"
                    className="block w-full p-3 pl-10 text-sm border-gray-200 rounded-md focus:border-blue-500 focus:ring-blue-500 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400"
                    placeholder="Search..."
                    onClick={handleSearch}
                />
                <div className="absolute inset-y-0 left-0 flex items-center pl-4 pointer-events-none">
                    <svg
                        className="h-3.5 w-3.5 text-gray-400"
                        xmlns="http://www.w3.org/2000/svg"
                        width="16"
                        height="16"
                        fill="currentColor"
                        viewBox="0 0 16 16"
                    >
                        <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z" />
                    </svg>
                </div>
            </div>

            <div className="flex items-center space-x-2 mr-72">
                <div className="">
                    <button className=" z-0 inline-flex text-sm rounded-md shadow-sm focus:ring-accent-500 focus:border-accent-500 hover:bg-gray-50 focus:z-10 focus:outline-none focus:ring-1">
                        <span className=" inline-flex items-center px-3 py-3 space-x-2 text-sm font-medium text-gray-600 bg-white border border-gray-300 rounded-md sm:py-2">
                            <div>
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    className="w-3 h-3"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    stroke="currentColor"
                                    strokeWidth={2}
                                >
                                    <path
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                        d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z"
                                    />
                                </svg>
                            </div>
                            <div className="hidden sm:block">
                                Filters
                            </div>
                        </span>
                    </button>
                </div>
            </div>
            <div className="flex items-center space-x-2 mr-72">
                <div className="">
                    <button className=" z-0 inline-flex text-sm rounded-md shadow-sm focus:ring-accent-500 focus:border-accent-500 hover:bg-gray-50 focus:z-10 focus:outline-none focus:ring-1">
                        <span className=" inline-flex items-center px-3 py-3 space-x-2 text-sm font-medium text-gray-600 bg-white border border-gray-300 rounded-md sm:py-2">
                            <div>
                            <svg 
                              xmlns="http://www.w3.org/2000/svg" 
                              fill="none" 
                              viewBox="0 0 24 24" 
                              stroke-width="1.5" 
                              stroke="currentColor" 
                              class="w-6 h-6">
                              <path 
                              stroke-linecap="round" 
                              stroke-linejoin="round" 
                              d="M12 4.5v15m7.5-7.5h-15" />
                            </svg>
                            </div>
                            <div >      
                                <button onClick={() => setShowForm(!showForm)}>
                                    {showForm ? 'Close' : 'Add'} User
                                </button> 
                                
                                {showForm && (
                                    <div className="fixed inset-0 flex items-center justify-center bg-gray-600 bg-opacity-25  ">  
                                    <div class="flex justify-end px-4 pt-4"> 
                                      <svg 
                                        xmlns="http://www.w3.org/2000/svg" 
                                        fill="none" viewBox="0 0 24 24" 
                                        stroke-width="1.5" 
                                        stroke="currentColor" 
                                        class="w-6 h-6">
                                        <path 
                                        stroke-linecap="round" 
                                        stroke-linejoin="round" 
                                        d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                                        </svg>
                                    </div>
                                    <Card color="white"  shadow={false}>
                                        <Typography variant="h4" color="blue-gray">
                                        ADD USER
                                        </Typography>
                                        <form className="mt-8 mb-2 w-80 max-w-screen-lg sm:w-96 bg-white bg-auto p-34">
                                      

                                        <div className="mb-4 flex flex-col gap-6">
                                            <Input size="lg" label="Name" />
                                            <Input size="lg" label="Email" />
                                            <Input size="lg" label="Username" />
                                            <Input type="password" size="lg" label="Password" />
                                        </div>
                                    <Button className="mt-6" fullWidth>
                                        ADD
                                    </Button>
                                    </form>
                                </Card>
                                    </div>    
                                )}
                        </div>  
                        </span>
                    </button>
                </div>
            </div>
        </div>

        <div className="p-1.5 w-9/12  ">
            <div className="overflow-hidden border rounded-lg">
                <table className="min-w-full divide-y divide-gray-200">
                    <thead className="bg-gray-50">
                        <tr>
                            <th scope="col" className="py-3 pl-4">
                                <div className="flex items-center h-5">
                                    <input
                                        id="checkbox-all"
                                        type="checkbox"
                                        className="text-blue-600 border-gray-200 rounded focus:ring-blue-500"
                                    />
                                    <label
                                        htmlFor="checkbox"
                                        className="sr-only"
                                    >
                                        Checkbox
                                    </label>
                                </div>
                            </th>
                            <th
                                scope="col"
                                className="px-6 py-3 text-xs font-bold text-left text-gray-500 uppercase "
                            >
                                ID
                            </th>
                            <th
                                scope="col"
                                className="px-6 py-3 text-xs font-bold text-left text-gray-500 uppercase "
                            >
                                Email
                            </th>
                            <th
                                scope="col"
                                className="px-6 py-3 text-xs font-bold text-left text-gray-500 uppercase "
                            >
                                Username
                            </th>
                            <th
                                scope="col"
                                className="px-6 py-3 text-xs font-bold text-right text-gray-500 uppercase "
                            >
                                Edit
                            </th>
                            <th
                                scope="col"
                                className="px-6 py-3 text-xs font-bold text-right text-gray-500 uppercase "
                            >
                                Delete
                            </th>
                        </tr>
                    </thead>
                    <tbody className="divide-y divide-gray-200">
                    {filteredusers.length > 0 &&
                    filteredusers.map(user => ( 
                        <tr key={user}>
                            <td className="py-3 pl-4">
                                <div className="flex items-center h-5">
                                    <input
                                        type="checkbox"
                                        className="text-blue-600 border-gray-200 rounded focus:ring-blue-500"
                                    />
                                    <label
                                        htmlFor="checkbox"
                                        className="sr-only"
                                    >
                                        Checkbox
                                    </label>
                                </div>
                            </td>
                            <td className="px-6 py-4 text-sm font-medium text-gray-800 whitespace-nowrap">
                                {filteredusers.indexOf(user)}
                            </td>
                            <td className="px-6 py-4 text-sm text-gray-800 whitespace-nowrap">
                              {user.email}
                            </td>
                            <td className="px-6 py-4 text-sm text-gray-800 whitespace-nowrap">
                              {user.username}
                            </td>
                            <td className="px-6 py-4 text-sm font-medium text-right whitespace-nowrap text-green-500 hover:text-green-700">
                                <button>Edit</button>
                                    
                            </td>
                            <td className="px-6 py-4 text-sm font-medium text-right whitespace-nowrap text-red-500 hover:text-red-700">
                                   <button onClick={() => handleDelete(user)}>Delete</button> 
                            </td>
                        </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
);
}

export default UserTable;
