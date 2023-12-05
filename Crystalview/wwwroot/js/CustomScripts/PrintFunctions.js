

//#region set the doamin so we can call reports directly
var dd = window.location.hostname.slice(window.location.hostname.indexOf('.') + 1);
document.domain = (dd.length < 3 ? 'LocalHost' : dd);//'datatech-eg.com';

//#region print i frame from iside and keep hidden
function closePrint() {
    document.body.removeChild(this.__container__);
}

function setPrint() {

    this.contentWindow.__container__ = this;
    this.contentWindow.onbeforeunload = closePrint;
    this.contentWindow.onafterprint = closePrint;
    this.contentWindow.focus(); // Required for IE
    //this.contentWindow.print();

    //give time to geenrate report
    setTimeout(this.contentWindow.print(), 3000);
}

function printPage(sURL) {
    var oHiddFrame = document.createElement("iframe");
    oHiddFrame.onload = setPrint;
    oHiddFrame.style.visibility = "hidden";
    oHiddFrame.style.position = "fixed";
    oHiddFrame.style.right = "0";
    oHiddFrame.style.bottom = "0";
    oHiddFrame.src = sURL;
    console.log(oHiddFrame);
    document.body.appendChild(oHiddFrame);
}
            //#endregion
