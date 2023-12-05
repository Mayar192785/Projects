import Auditchart from "../components/AuditTrailchart";
import SidebarAuditor from "../components/SideBarAuditor";

export default function AuditTrail(){
    return(
        <>
        <SidebarAuditor></SidebarAuditor>
        <Auditchart></Auditchart>
        </>
    )
}