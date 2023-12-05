export default function Header({
    heading
}){
    return(
        <div className="mb-10 mt-20">
            <div className="flex justify-center">
                <img 
                    alt=""
                    className="h-40 w-40"
                    src="https://iconrex.com/wp-content/uploads/2022/01/Log-In-Icon-1.svg"/>
            </div>
            <h2 className="mt-6 text-center text-3xl font-extrabold text-gray-900">
                {heading}
            </h2>
        </div>
    )
}