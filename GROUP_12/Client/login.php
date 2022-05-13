<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">

    <title>Login/Sign up</title>
    
    
  <link rel="stylesheet" href="path/to/fontawesome.min.css">


  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    
    
    <!--css file-->
    <link rel="stylesheet" href="Ahmed200483.css">
    <link rel="stylesheet" href="Dactarastyle.css">
    
    <!--font awesome icons file-->
    <script src="https://kit.fontawesome.com/a076d05399.js" ></script>


    <!--slider file-->
    <link rel="stylesheet" href="https://unpkg.com/swiper@8/swiper-bundle.min.css"/>
  
    <nav>
      <img class="logo" src="Images/LogoMakr-85XoZT.png">
      
      <div class="ham" >  
        <span class="bar1"></span>  
        <span class="bar2"></span>  
        <span class="bar3"></span>  
      </div>  

      <ul class="nav-sub">
          <li><a class="active" href="Home.html">Home</a></li>
          <li><a class="active" href="Reservation.html">Reservation</a></li>
          <li><a class="active" href="offers.html">Offers</a></li>
          <li><a class="active" href="Counsoltation.html">Counsoltation</a></li>
          <li><a class="active" href="aboutus.html">About US</a></li>
          <li><a href="login.html" id="signButton" class="btn btn-outline-light btn-rounded" style="border-radius: 100px;" >Sign up / log in</a></li> 
      </ul>
  </nav>
  
  <!--    nav bar script -->
  <script>

      const hamburger = document.querySelector(".ham"); 
      
      const navsub = document.querySelector(".nav-sub"); 
      
      hamburger.addEventListener('click', () => {  
      hamburger.classList.toggle("change")  
      navsub.classList.toggle("nav-change")  
      }); 

  </script>
</head>
    <body>
        
  
   

	<div class="section">
		<div class="container">
    			<div class="row full-height justify-content-center">
				<div class="col-12 text-center align-self-center py-5">
					<div class="section pb-5 pt-5 pt-sm-2 text-center">
						<h6 class="mb-0 pb-3"><span>Log In </span><span>Sign Up</span></h6>
			          	<input class="checkbox" type="checkbox" id="reg-log" name="reg-log"/>
			          	<label for="reg-log"></label>
						<div class="card-3d-wrap mx-auto">
							<div class="card-3d-wrapper">
								<div class="card-front">
									<div class="center-wrap">
										<div class="section text-center">
											<h4 class="mb-4 pb-3">Log In</h4>
                    
											<div class="form-group">
												<input type="email" name="email" class="form-style" placeholder="Your Email" id="logemail" autocomplete="off" >
												<i class="input-icon uil uil-at"></i>
											</div>	
											<div class="form-group mt-2">
												<input type="password" name="pass" class="form-style" placeholder="Your Password" id="logpass" autocomplete="off" >
												<i class="input-icon uil uil-lock-alt"></i>
											</div>
											<button type="submit" class="btn mt-4" name="login" >LOGIN</button>
                          <div>
                            <input type = "checkbox" name = "remember" value = "rememberme" id = rad><label><b>Remember me</b></label>
                            </div>
                        <p class="mb-0 mt-4 text-center"><a href="#" class="link">Forgot your password?</a></p>
				      					</div>
                                   
			      					</div>
			      				</div>
								<div class="card-back">
									<div class="center-wrap">
										<div class="section text-center">
											<h4 class="mb-4 pb-3">Sign Up</h4>
											<div class="form-group">
												<input type="text" name="logname" class="form-style" placeholder="Your UserName" id="logname" autocomplete="off" method="Post">
												<i class="input-icon uil uil-user"></i>
											</div>	
											<div class="form-group mt-2">
												<input type="email" name="logemail" class="form-style" placeholder="Your Email" id="logemail" autocomplete="off" method="Post">
												<i class="input-icon uil uil-at"></i>
											</div>	
											<div class="form-group mt-2">
												<input type="password" name="logpass" class="form-style" placeholder="Your Password" id="logpass" autocomplete="off" method="Post">
												<i class="input-icon uil uil-lock-alt"></i>
											</div>
                        <div class="form-group mt-2">
												<input type="text" name="logphone" class="form-style" placeholder="Your Phone number" id="logpass" autocomplete="off" method="Post">
												<i class="input-icon uil uil-lock-alt"></i>
											</div>
											<button type="submit" class="btn mt-4" name="signup" method="Post">SIGNUP</button>
                        <div>
                        <input type="checkbox" name = "remember" value = "rememberme" id = rad><label><b>Remember me</b></label>
                          </div>
				      					</div>
			      					</div>
			      				</div>
			      			</div>
			      		</div>
			      	</div>
		      	</div>
	      	</div>
        
	    </div>
	</div>
    
    </body>

    <style>

@import url('https://fonts.googleapis.com/css?family=Poppins:400,500,600,700,800,900');

body{
	font-family: 'Poppins', sans-serif;
	font-weight: 300;
	font-size: 15px;
	line-height: 1.7;
	color: #333;
	background-image: url(https://cdn.wallpapersafari.com/8/37/AcPoTn.jpg);
	overflow-x: hidden;
}
    
a {
	cursor: pointer;
    transition: all 200ms linear;
}
    
a:hover {
	text-decoration: none;
}
    
.link {
  color: #333;
}
    
.link:hover {
  color: whitesmoke;
}
    
p {
  font-weight: 500;
  font-size: 14px;
  line-height: 1.7;
}
    
h4 {
  font-weight: 600;
}
    
h6 span{
  padding: 0 20px;
  text-transform: uppercase;
  font-weight: 700;
}
    
.section{
  position: relative;
  width: 100%;
  display: block;
}
    
.full-height{
  min-height: 100vh;
}
    
[type="checkbox"]:checked,
[type="checkbox"]:not(:checked){
  position: absolute;
  left: -9999px;
}
    
.checkbox:checked + label,
.checkbox:not(:checked) + label{
  position: relative;
  display: block;
  text-align: center;
  width: 60px;
  height: 16px;
  border-radius: 8px;
  padding: 0;
  margin: 10px auto;
  cursor: pointer;
  background-color: royalblue;
}
    
.checkbox:checked + label:before,
.checkbox:not(:checked) + label:before{
  position: absolute;
  display: block;
  width: 36px;
  height: 36px;
  border-radius: 50%;
  color: whitesmoke;
  background-color: #3a9efd;
  font-family: 'unicons';
  content: '\eb4f';
  z-index: 20;
  top: -10px;
  left: -10px;
  line-height: 36px;
  text-align: center;
  font-size: 24px;
  transition: all 0.5s ease;
}
    
.checkbox:checked + label:before {
  transform: translateX(44px) rotate(-270deg);
}

.card-3d-wrap {
  position: relative;
  width: 440px;
  max-width: 100%;
  height: 400px;
  transform-style: preserve-3d;
  perspective: 800px;
  margin-top: 60px;
}
    
.card-3d-wrapper {
  width: 100%;
  height: 100%;
  position:absolute;    
  top: 0;
  left: 0;  
  transform-style: preserve-3d;
  transition: all 600ms ease-out; 
}
    
.card-front, .card-back {
  width: 100%;
  height: 100%;
  background-color: #78c1ff;
  background-image: url('https://s3-us-west-2.amazonaws.com/s.cdpn.io/1462889/pat.svg');
  background-position: bottom center;
  background-repeat: no-repeat;
  background-size: 300%;
  position: absolute;
  border-radius: 6px;
  left: 0;
  top: 0;
  transform-style: preserve-3d;
  backface-visibility: hidden;
}
.card-back {
  transform: rotateY(180deg);
}
.checkbox:checked ~ .card-3d-wrap .card-3d-wrapper {
  transform: rotateY(180deg);
}
.center-wrap{
  position: absolute;
  width: 100%;
  padding: 0 35px;
  top: 50%;
  left: 0;
  transform: translate3d(0, -50%, 35px) perspective(100px);
  z-index: 20;
  display: block;
}


.form-group{ 
  position: relative;
  display: block;
    margin: 0;
    padding: 0;
}
    
.form-style {
  padding: 13px 20px;
  padding-left: 55px;
  height: 48px;
  width: 100%;
  font-weight: 500;
  border-radius: 4px;
  font-size: 14px;
  line-height: 22px;
  letter-spacing: 0.5px;
  outline: none;
  color: #333;
  background-color: whitesmoke;
  border: none;
  transition: all 200ms linear;
  box-shadow: 0 4px 8px 0 rgba(21,21,21,.2);
}

.btn:hover{  
  background-color: whitesmoke;
  color: #333;
  box-shadow: 0 8px 24px 0 rgba(16,39,112,.2);
}


.logo {
	top: 30px;
	right: 30px;
	display: block;
	z-index: 100;
	transition: all 250ms linear;
    float: left;
}
    
.logo img {
	width: 90%;
	display: block;
}

</style>

</html>

<?php

require_once('C:/aa/htdocs/GROUP_12/Admin/Admin_connect.php');
if(isset($_POST['login'])){
    $email= $_POST['email'];
    $pass= $_POST['pass'];

    $offerlist = $conn->query("SELECT * FROM guest WHERE Guest_Email=('$email') AND Guest_Password=('$pass')"); 
    $offerdata = $offerlist->fetchALL(PDO::FETCH_ASSOC);

    if (!empty($_POST['email'])&& !empty($POST['pass'])) {
 
    header("location:Home.html");
    session_start();
    $_SESSION['Email']=$_POST['email'];
    $_SESSION['Password']=$_POST['pass'];
    }
    if($_POST['remember'] == "rememberme")
    {
        setcookie("username", $username, time() + 300);
    }
}

 else if(isset($_POST['signup'])){
    
    function validate($input)
    {
        $data = trim($input);
        $data = stripslashes($data);
        $data = htmlspecialchars($data);
        return $data;
    }
    $i=30;
    $i=$i+1;
    $guestId=$i;
    $logname=validate($_POST['logname']);
    $logemail=validate($_POST['logemail']);
    $logpass=validate($_POST['logpass']);
    $logphone=validate($_POST['logphone']);

    $result=$conn->query("INSERT INTO guest (Guest_ID,Guest_Username,Guest_Password,Guest_Email,Guest_PhoneNumber) VALUES ('$guestId','$logname','$logpass','$logemail','$logphone')");

    if($result){
        echo '<script>alert("Signed up successfully")</script>';
        header("location:Home.html");
        session_start();
        $_SESSION['Email']=$_POST['logemail'];
        $_SESSION['Password']=$_POST['logpass'];
    
    }
    if($_POST['remember'] == "rememberme")
    {
        setcookie("username", $username, time() + 300);
    }
}


?>