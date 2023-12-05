
if (document.getElementById("GridConfigure") !== null)
document.getElementById("GridConfigure").addEventListener("click", function () {
    new MvcGrid(document.querySelector(".mvc-grid")).showConfiguration(this);
});

document.addEventListener("gridconfigure", e => {
    const configuration = e.detail.grid.getConfiguration();
    var GridName = document.querySelector(".mvc-grid").id;
    // Save configuration to a cookie/backend/etc.
    //window.localStorage.setItem(GridName, configuration);
    Cookies.set(GridName, JSON.stringify(configuration), { expires: 365 })
});
// new in 6.2
//const gridconfiguration = localStorage.getItem("grid-config");
//const grid = new MvcGrid(document.querySelector(".mvc-grid"));

//if (configuration) {
//    // Client side configuration function
//    grid.configure(JSON.parse(configuration));
//}