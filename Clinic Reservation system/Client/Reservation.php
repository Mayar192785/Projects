<!--Alaa179280-->
<!--Reservation Page-->
<!DOCTYPE html>
<html>
<head>
<title>Reservation</title>
	  <link rel="stylesheet" href="Dactarastyle.css">
	<link rel="icon" type="logo/png" href="images/logo.png">
<!--    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">   -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>  
<meta name="viewport" content="width=device-width, initial-scale=1">
    
<style>
* {box-sizing: border-box;}
body {font-family: Verdana, sans-serif;}
.mySlides {display: none;}
img {vertical-align: middle;}


.slideshow-container {
  max-width: 1000px;
  position: relative;
  margin: auto;
}


.text {
  color: gray;
  font-size: 30px;
  padding: 10px 12px;
  position: absolute;
  bottom: 170px;
  width: 50%;
  text-align: Left;
}


.dot {
  height: 15px;
  width: 15px;
  margin: 0 2px;
  background-color: #bbb;
  border-radius: 50%;
    
  display: inline-block;
  transition: background-color 0.6s ease;
}

.active {
  background-color: #717171;
}


.fade {
  animation-name: fade;
  animation-duration: 1.5s;
}


@media only screen and (max-width: 300px) {
  .text {font-size: 11px}
}
    .scroll_To_Top{
		width:5px;
		height:5px; 
	    color: black;
		text-decoration: none;
		position:fixed;
		padding:10px; 
		text-align:right; 
		font-weight: bold;
		top:100px;
		right:50px;
		
	}
		


.column {
  float: left;
  padding: 10px;

}

.left, .right {
  width: 25%;
  height: 200px;
}


.middle {
  width: 50%;
  height: 300px;
}


.row:after {
  content: "";
  display: table;
  clear: both;
}
    div.a{
        font-size: 20px;
        text-align:center;
        color: burlywood
            
    }
    
    div.b{
        font-size: 15px;
        text-align: center;
        color: gray
    }
    
     div.c{
        font-size: 30px;
        text-align: center;
        color: burlywood
    }
    
    
    .open-button {
  background-color: cadetblue;
  color: white;
  padding: 16px 20px;
  border: none;
  cursor: pointer;
  opacity: 0.8;
  position:static;
  bottom: 30px;
  width: 180px;
 
}


.form-popup {
  display: none;
  position: fixed;
  bottom: 0;
  right: 60px;
  border: 3px solid #f1f1f1;
  z-index: 5;
}


.form-container {
  max-width: 500px;
  padding: 10px;
  background-color: aliceblue;
}


.form-container input[type=text], .form-container input[type=password] {
  width: 60%;
  padding: 15px;
  margin: 5px 0 22px 0;
  border: none;
  background: #f1f1f1;
}




.form-container .btn {
  background-color: cadetblue;
  color: white;
  padding: 16px 20px;
  border: none;
  cursor: pointer;
  width: 100%;
  margin-bottom:10px;
  opacity: 0.8;
}


.form-container .cancel {
  background-color: red;
}


.form-container .btn:hover, .open-button:hover {
  opacity: 1;
}
     <div>

	<a href="#" class="scroll_To_Top"> <span><img src=images/UP.png alt="MoveUP" width="50" height="50" ></span></a>
			
    </div>
 * {
  box-sizing: border-box;
   border-radius: 50%;
}

.columnb {
  float: left;
  width: 20%;
  padding: 5px;
}


.rowb::after {
  content: "";
  clear: both;
  display: table;
}
    #panel, #flip {
  padding: 5px;
  text-align: center;
  background-color:aliceblue;

}

#panel {
  padding: 50px;
  text-align: left;
    display: none;
}
    
     #panel1, #flip1 {
  padding: 5px;
  text-align: center;
  background-color:aliceblue;

}

#panel1 {
  padding: 50px;
      text-align: left;
    display: none;
}
    
     #panel2, #flip2 {
  padding: 5px;
  text-align: center;
  background-color:aliceblue;

}

#panel2 {
  padding: 50px;
      text-align: left;
    display: none;
}
  
        #panel3, #flip3 {
  padding: 5px;
  text-align: center;
  background-color:aliceblue;

}

#panel3 {
  padding: 50px;
      text-align: left;
    display: none;
}
    
    #panel4, #flip4 {
  padding: 5px;
  text-align: center;
  background-color:aliceblue;

}

#panel4 {
  padding: 50px;
      text-align: left;
    display: none;
}
    span.form-required {
    color: red;
}

</style>
</head>

<body>
    <nav>
        <img class="logo" src="images/logo.png">
        
        <ul>
            <li><a class="active" href="Home.php">Home</a></li>
            <li><a class="active" href="Reservation.php">Reservation</a></li>
            <li><a class="active" href="offers.php">Offers</a></li>
            <li><a class="active" href="Counsoltation.php">Counsoltation</a></li>
            <li><a class="active" href="aboutus.html">About US</a></li>
            <li><a href="#" class="btn btn-outline-light btn-rounded" style="border-radius: 100px;" >Sign up / log in</a></li> 
        </ul>
       
    </nav>
   
    
<div class="slideshow-container">

<div class="mySlides fade">
 
  <img src="images/BG2.jpg" style="width:100%">
  <div class="text">"IT IS HEALTH,THAT IS REAL WEALTH"</div>
</div>

<div class="mySlides fade">
 
  <img src="images/BG1.jpg" style="width:100%">
  <div class="text">"DON'T SUFFER IN SILENCE, YOU DON'T HAVE TO, GO TO THE DOCTOR"</div>
</div>

<div class="mySlides fade">

  <img src="images/BG3.jpg" style="width:100%">
  <div class="text">"MEDICINES CURE DISEASES, BUT ONLY DOCTORS CAN CURE PATIENTS"</div>
</div>
</div>    
<div style="text-align:center">
  <span class="dot"></span> 
  <span class="dot"></span> 
  <span class="dot"></span> 
</div>
    
      <div>
	<a href="#" class="scroll_To_Top"> <span><img src=images/UP.png alt="MoveUP" width="50" height="50" ></span></a>	
    </div>
    
  <div class="row">
  <div class="column left" style="background-color:aliceblue;">
    <div class = "a"> <img src=images/call2.png alt="call" width="30" height="30" > <b>Emergencyy Cases</b>  </div>
      <div class = "b">
          Call: 
            16012
            <br>
      We care about your health.
          <br>
                call us!
          <br>
          We are here for you.
      </div>
        
  </div>
  <div class="column middle" style="background-color:powderblue;">
    <div class = "c"> <img src=images/Calendar.png alt="Time" width="50" height="50" > <b>Appointments</b>  </div>
      <div class = "b">
          The first step toward a healthy life is to schedule an appointment.Please fill the appointment form.
          </div>
      
          <button class="open-button" onclick="openForm()">Appoint Now!</button>

<div class="form-popup" id="myForm">
    <form method="POST" enctype="multipart/form-data" name="registration"class="form-container" >
     
<div class ="b">
    <h1>Appoint A Doctor</h1>
   
    <ul>
<li><label for="Reservation_ID">Reservation Number:<span class="form-required"> * </span></label></li>
<input type="text" name="Reservation_ID" required size="50" />
        
           <br>
        
        
<li><label for="Reservation_Type">Appointment Type:<span class="form-required"> * </span> </label></li>

<select name="Reservation_Type" required>
<option selected="" value="Default">(Please select a type)</option>
<option value="Otorhinolaryngologist">Otorhinolaryngologist</option>
<option value="Dentist">Dentist</option>
<option value="pediatrician">pediatrician</option>
<option value="Ophthalmologist">Ophthalmologist</option>
<option value="Orthopedist">Orthopedist</option>
</select>
    
<li><label for="Reservation_Time">Reservation Time:<span class="form-required"> * </span></label></li>
<input type="time" name="Reservation_Time" required size="50" />
        
    
 <li><label for="Reservation_Date">Reservation Date:<span class="form-required"> * </span></label></li>
<input type="date" name="Reservation_Date" required size="50" />   
  
        
<li><label for="desc">Comment:</label></li>
<textarea name="desc" id="desc"></textarea>

    <button type="submit" class="btn" name="Add" >Submit</button> 
    <button type="button" class="btn cancel" onclick="closeForm()">Close</button>
        
      </ul>
    </div>
  </form>
      </div>
      
      
  </div>
  <div class="column right" style="background-color:aliceblue;">
     <div class = "a"> <img src=images/clock3.png alt="clock" width="30" height="30" > <b>Opening Hours</b>  </div>
      <div class = "b">
          SAT-WED:     8:00Am - 9:00PM
          <br><br>
          Thursday:    10:AM - 8:00PM
          <br><br>
          Friday:      1:PM - 8:00PM
      </div>
  </div>
</div>
     <div class="rowb">
         <div class="columnb">
    <div id="flip"><img src="images/Dentist.jpg" alt="Dentist" style="width:180px"></div>
<div id="panel">
    <div class = "a"> Dentist:</div>
    <br>
    <div class = "b">
      - DR.Omar Amer:
        <br>
        *Address:Madinaty,
        Medicalcenter 1 clinic 401
        <br>
        *Detection Price: 250EGP
        <br><br>
        - DR.Tarek Hosny:
        <br>
        *Address:Zayed,Jezirah plaza
        <br>
        *Detection Price 200EGP
      </div>
             
             </div> 
             </div>
         
 <div class="columnb">
    <div id="flip1"><img src="images/ear.png" alt="ear" style="width:180px"></div>
<div id="panel1">
    <div class = "a"><small> Otorhinolaryngologist:</small></div>
    <br>
    <div class = "b">
      - DR.Hesham Mansour:
        <br>
        *Address:New Cairo,
        Medicalcenter,clinic 15
        <br>
        *Detection Price: 400EGP
        <br><br>
        - DR.Ahmed Abdelkhaliek:
        <br>
        *Address:Zayed,Twin Towers
        <br>
        *Detection Price 300EGP
      </div>
             
             </div>  
         </div>
         
          <div class="columnb">
    <div id="flip2"><img src="images/kid2.png" alt="ear" style="width:220px"></div>
<div id="panel2">
    <div class = "a"><small> pediatrician:</small></div>
    <br>
    <div class = "b">
      - DR.Ahmed Mamdouh:
        <br>
        *Address:Madinaty,
        Medicalcenter1,clinic 202
        <br>
        *Detection Price: 150EGP
        <br><br>
        - DR.Hassan Tarek:
        <br>
        *Address:El sherouk,Medical Park
        <br>
        *Detection Price 150EGP
      </div>
             
             </div>  
               
         </div>
             <div class="columnb">
    <div id="flip3"><img src="images/eye2.png" alt="ear" style="width:180px"></div>
<div id="panel3">
    <div class = "a"><small> Ophthalmologist:</small></div>
    <br>
    <div class = "b">
      - DR.Tarek Abdelhares:
        <br>
        *Address:Marghany,
        Nour center
        <br>
        *Detection Price: 300EGP
        <br><br>
        - DR.Tamer el regal:
        <br>
        *Address:Cairo,1 Thawra St.
        <br>
        *Detection Price 400EGP
      </div>
             
             </div>  
               
         </div>
         
              <div class="columnb">
    <div id="flip4"><img src="images/bones.png" alt="ear" style="width:180px"></div>
<div id="panel4">
    <div class = "a"><small> Orthopedist:</small></div>
    <br>
    <div class = "b">
      - DR.Hamdy Samey:
        <br>
        *Address:NewCairo,
        Nourth Tesine
        <br>
        *Detection Price: 300EGP
        <br><br>
        - DR.Ahmed Alam:
        <br>
        *Address:Cairo,15Thawra St.
        <br>
        *Detection Price 300EGP
      </div>
             
             </div>  
               
         </div>
         </div>
<script>
let slideIndex = 0;
showSlides();

function showSlides() {
  let i;
  let slides = document.getElementsByClassName("mySlides");
  let dots = document.getElementsByClassName("dot");
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";  
  }
  slideIndex++;
  if (slideIndex > slides.length) {slideIndex = 1}    
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex-1].style.display = "block";  
  dots[slideIndex-1].className += " active";
  setTimeout(showSlides, 2000); // Change image every 2 seconds
}
</script>
    <script src="https://code.jquery.com/jquery-2.1.1.js"></script>
    

<script>
$(document).ready(function(){
	
	$(window).scroll(function(){
		if ($(this).scrollTop() > 100) 
		{
			$('.scroll_To_Top').fadeIn();
		} 
		else 
		{
			$('.scroll_To_Top').fadeOut();
		}
	});
	

	$('.scroll_To_Top').click(function(){
		$('html, body').animate({scrollTop : 0},700);
		return false;
	});
	
});
</script>
    <script>
function openForm() {
  document.getElementById("myForm").style.display = "block";
}

function closeForm() {
  document.getElementById("myForm").style.display = "none";
}
</script>
<script>
function validateForm() {
  let x = document.forms["reservation"]["username"].value; 
  if (x == "") {
   alert("Required");
    return false;
  }
}
</script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script> 
$(document).ready(function(){
  $("#flip").click(function(){
    $("#panel").slideToggle("slow");
  });
});
</script>
           <script> 
$(document).ready(function(){
  $("#flip1").click(function(){
    $("#panel1").slideToggle("slow");
  });
});
</script> 
               <script> 
$(document).ready(function(){
  $("#flip2").click(function(){
    $("#panel2").slideToggle("slow");
  });
});
</script> 
    
    <script> 
$(document).ready(function(){
  $("#flip3").click(function(){
    $("#panel3").slideToggle("slow");
  });
});
</script> 
     <script> 
$(document).ready(function(){
  $("#flip4").click(function(){
    $("#panel4").slideToggle("slow");
  });
});
</script> 
    </body>
    <br>
    <footer>
 <div class="row">
  <div class="column">
      <img src="Images/logo.png" width="90%">
     </div>  
     
   <div class="column">
      <ul>
           <li><h4>Explore</h4></li>
           <Li><a href="#">Home</a></Li> 
           <Li><a href="#">Reservation</a></Li> 
           <Li><a href="#">Offers</a></Li> 
           <Li><a href="#">Counsolation</a></Li> 
      </ul>
     </div>
     
   <div class="column">
      <ul >
           <li><h4>Social</h4></li>
           <Li><a href="#">YouTube</a></Li> 
           <Li><a href="#">Instagram</a></Li> 
           <Li><a href="#">FaceBook</a></Li> 
      </ul>
     </div>
     
   <div class="column">
      <ul>
           <li><h4>Help</h4></li>
           <Li><a href="#">Contact US</a></Li> 
           <Li><a href="#">About</a></Li> 
            
      </ul>
     </div>
</div>
</footer>
</html>
<?php
// define variables and set to empty values
$Reservation_IDErr = $Reservation_TypeErr = $Reservation_TimeErr = $Reservation_DateErr = "";
$Reservation_ID = $Reservation_Type = $Reservation_Time = $Reservation_Date = "";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
  if (empty($_POST["Reservation_ID"])) {
    $Reservation_IDErr = "Number is required";
  } else {
    $Reservation_ID = test_input($_POST["Reservation_ID"]);
  }
  
  if (empty($_POST["Reservation_Type"])) {
    $Reservation_TypeErr = "Type is required";
  } else {
    $Reservation_Type = test_input($_POST["Reservation_Type"]);
  }
    
  if (empty($_POST["Reservation_Time"])) {
     $Reservation_TimeErr = "Time is required";
  } else {
    $Reservation_Time = test_input($_POST["Reservation_Time"]);
  }
 if (empty($_POST["Reservation_Date"])) {
     $Reservation_DateErr = "Date is required";
  } else {
    $Reservation_Date = test_input($_POST["Reservation_Date"]);
  }
}

function test_input($data) {
  $data = trim($data);
  $data = stripslashes($data);
  $data = htmlspecialchars($data);
  return $data;
}
?>

<?php
try {
    $conn = new PDO("mysql:host=localhost;dbname=dactara", "root", "");
} catch (PDOException $e) {
    echo $e->getMessage();
    exit();
}
if(isset($_POST['Add'])){

$Reservation_ID=$_POST['Reservation_ID'];
$Reservation_Type=$_POST['Reservation_Type'];
$Reservation_Time=$_POST['Reservation_Time'];
$Reservation_Date=$_POST['Reservation_Date'];

    $result = $conn->query("INSERT INTO reservation (Reservation_ID, Reservation_Type,Reservation_Time, Reservation_Date) VALUES ('$Reservation_ID','$Reservation_Type','$Reservation_Time','$Reservation_Date')");

    if ($result) {
     echo '<script>alert("Reservation added successfully")</script>';
    }
 
} 
?>