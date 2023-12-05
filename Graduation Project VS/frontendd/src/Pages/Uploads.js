import FileUpload from "../components/FileUpload";
import HistoryFile from "../components/HistoryFile";
import SidebarEmployee from "../components/SidebarEmployee";

export default function Uploads(){
    return(
        <>
        <SidebarEmployee></SidebarEmployee>
        <FileUpload></FileUpload>
        <HistoryFile></HistoryFile>
        </>
        
    )
}