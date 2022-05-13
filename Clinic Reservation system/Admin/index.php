

<html>

<body>
<form  method="Post" enctype="multipart/form-data">

<h1 style="text-align: center;
    font-size: 200%;
    font-family: 'Playfair Display';
    color: mediumpurple;
    margin-top:5%;">LOGIN</h1>
  <div class="container">
    <label for="uname"><b>Username</b></label>
    <input type="text" placeholder="Enter Username" name="uname" required>
<br>
    <label for="psw"><b>Password</b></label>
    <input type="password" placeholder="Enter Password" name="psw" required>

  <div>
    <input type="radio" name="accessType" value="1" id = rad required><label><b>Admin</b></label>
    <input type="radio" name="accessType" value="0" id = rad required><label><b>Patient</b></label>
  </div>

    <button type="submit" name="login">Login</button>
    <br>
    <label>
      <input type="checkbox" checked="checked" name="remember" required> Remember me
    </label>
  </div>

  
</form>

</body>

</html>
<style>

body{
background-image: url(https://cdn.wallpapersafari.com/8/37/AcPoTn.jpg);


}


/* Full-width inputs */
input[type=text], input[type=password] {
  width: 50%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;
}

/* Set a style for all buttons */
button {
  background-color: mediumpurple;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 50%;
}

/* Add a hover effect for buttons */
button:hover {
  opacity: 0.8;
}



/* Add padding to containers */
.container {
  padding: 16px;
  border:5px solid;
  border-color:#78c1ff;
  width:50%;
  text-align:center;
  margin:auto;
  margin-left:25%;
  margin-top:5%;

}

</style>
<?php

require_once('C:/aa/htdocs/GROUP_12/Admin/Admin_connect.php');
if(isset($_POST['login'])){

    $uname= $_POST['uname'];
    $psw= $_POST['psw'];
    $accessType=$_POST['accessType'];
    

    if ($accessType == 1) 
    {
        $userList = $conn->query("SELECT * FROM admin WHERE Admin_Username = '$uname' AND Admin_Password='$psw'");
        $userData = $userList->fetch(PDO::FETCH_ASSOC);

   
        echo "Admin accesed!";

        header("location: Admin_Dashboard.html");
        session_start();
        $_SESSION['Username']=$uname;
        $_SESSION['Password']=$psw;
    } 
    else if($accessType == 0)
    {
        $userList = $conn->query("SELECT * FROM guest WHERE Guest_Username= '$uname' AND Guest_Password='$psw' ");
        $userData = $userList->fetch(PDO::FETCH_ASSOC);

        echo "Patient accesed!";
        header("location:c:/aa/htdocs/GROUP_12/Client/Home.html");
        session_start();
        $_SESSION['Username']=$uname;
        $_SESSION['Password']=$psw;
    }
    else 
    {

        echo '<script>alert("The username, password, or access type is incorrect. Please try again.")</script>';
        header("location: index.php");
    }
    if($_POST['remember'] == "rememberme")
    {
        setcookie("username", $uname, time() + 300);
    }
}
?>
