import { useState } from 'react';
import { loginFields } from "../components/formfield";
import FormAction from "./FormAction";
import Input from "./Input";
import { useNavigate } from 'react-router-dom';

const fields = loginFields;
let fieldsState = {};
fields.forEach(field => fieldsState[field.id]='');

export default function Login(){
    const [loginState, setLoginState] = useState(fieldsState);
    const navigate = useNavigate();
    

    const handleChange = (e) => {
        setLoginState({...loginState, [e.target.id]: e.target.value})
    }

    const loginUser = async () => {
        fetch('http://localhost:3001/users/login', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({ 
              username: loginState.username, 
              password: loginState.password 
          })
        }).then(response => response.json())
        .then(data => {
            const { role } = data;
            if(role==="basic"){
                navigate("/EmpHome");
            }
            else if(role==="admin"){
                navigate("/home");
            }
            else if(role==="auditor"){
                navigate("/AuditorHome");
            }
            }
        ).catch(error=>alert("Failed to login. Try again later."));
    
    }
       
    const handleSubmit = (e) => {
        e.preventDefault();
        loginUser();
    }

    return(
        <div className=" flex items-center justify-center py-5 px-4 sm:px-6 lg:px-8">
            <div className="max-w-md w-full space-y-8">
                <form className="mt-8 space-y-6" onSubmit={handleSubmit}>
                    <div className="space-y-6">
                        {
                            fields.map(field =>
                                <Input
                                    key={field.id}
                                    handleChange={handleChange}
                                    value={loginState[field.id]}
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
                    </div>
                    <FormAction handleSubmit={handleSubmit} text="Login"/>
                    New account?{" "}
                    <a
                        href="/"
                        className="font-medium text-blue-500 transition-colors hover:text-blue-600"
                        >
                        Sign Up
                    </a>
                </form>
             </div>
        </div>
    )
}
