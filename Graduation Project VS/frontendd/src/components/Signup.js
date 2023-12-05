import { useState } from 'react';
import { SignupFields } from "../components/Signupfield";
import FormAction from "./FormAction";
import Input from "./Input";
import { useNavigate } from 'react-router-dom';

const fields = SignupFields;
let fieldsState = {};
fields.forEach(field => fieldsState[field.id]='');

export default function Signup(){
    const [signupState, setSignupState] = useState(fieldsState);
    const navigate = useNavigate();

    const handleChange = (e) => {
        setSignupState({...signupState, [e.target.id]: e.target.value})
    }

    const addUser = async () => {
        fetch('http://localhost:3001/addusesr', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({ 
              email: signupState.email, 
              username: signupState.username,
              password: signupState.password,
              role: signupState.role
          })
        }).then(response => response.json())
        .then(data => {
            const { message,role } = data;
            alert(message)
            if(message === "User added successfully"){
                if(role==="basic"){
                    navigate("/Emphome")
                }
                if(role==="Admin"){
                    navigate("/home")
                }
                if(role==="Auditor"){
                    navigate("/AuditorHome")
                }
            }
            
        }
        ).catch(error=>alert("Failed to Signup. Try again later."));
    
    }
       
    const handleSubmit = (e) => {
        e.preventDefault();
        addUser();
    }

    return(
        <div className=" flex items-center justify-center px-4 sm:px-6 lg:px-8">
            <div className="max-w-md w-full space-y-6">
                <form className=" space-y-6" onSubmit={handleSubmit}>
                    <div className="space-y-6">
                        {
                            fields.map(field =>
                                <Input
                                    key={field.id}
                                    handleChange={handleChange}
                                    value={signupState[field.id]}
                                    labelText={field.labelText}
                                    labelFor={field.labelFor}
                                    id={field.id}
                                    name={field.name}
                                    type={field.type}
                                    isRequired={field.isRequired}
                                    placeholder={field.placeholder}
                                />
                            )
                        }
                        
                        <ul class="items-center w-full text-sm font-medium text-gray-900 bg-white border border-gray-200 rounded-lg sm:flex dark:border-sky-600 dark:text-white">
                            <li class="w-full border-b border-gray-200 sm:border-b-0 sm:border-r dark:border-gray-600">
                                <div class="flex items-center pl-3">
                                    <input id="horizontal-list-radio-license" type="radio" value="" name="role" class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-700 dark:focus:ring-offset-gray-700 focus:ring-2 dark:bg-gray-600 dark:border-gray-500"/>
                                    <label for="horizontal-list-radio-license" class="w-full py-3 ml-2 text-sm font-medium text-gray-900 dark:text-gray-600">Basic </label>
                                </div>
                            </li>
                            <li class="w-full border-b border-gray-200 sm:border-b-0 sm:border-r dark:border-gray-600">
                                <div class="flex items-center pl-3">
                                    <input id="horizontal-list-radio-id" type="radio" value="" name="role" class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-700 dark:focus:ring-offset-gray-700 focus:ring-2 dark:bg-gray-600 dark:border-gray-500"/>
                                    <label for="horizontal-list-radio-id" class="w-full py-3 ml-2 text-sm font-medium text-gray-900 dark:text-gray-600">Admin</label>
                                </div>
                            </li>
                            <li class="w-full border-b border-gray-200 sm:border-b-0 sm:border-r dark:border-gray-600">
                                <div class="flex items-center pl-3">
                                    <input id="horizontal-list-radio-millitary" type="radio" value="" name="role" class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-700 dark:focus:ring-offset-gray-700 focus:ring-2 dark:bg-gray-600 dark:border-gray-500"/>
                                    <label for="horizontal-list-radio-millitary" class="w-full py-3 ml-2 text-sm font-medium text-gray-900 dark:text-gray-600">Auditor</label>
                                </div>
                            </li>
                        </ul>

                    </div>
                    <FormAction  text="Signup"/>
                    Already have an account?{" "}
                    <a
                        href="/login"
                        className="font-medium text-blue-500 transition-colors hover:text-blue-600"
                        >
                        Sign In
                    </a>
                </form>
            </div>
        </div>
    )
}
