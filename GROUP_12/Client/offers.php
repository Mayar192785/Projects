<!DOCTYPE HTML>
<html>
<head>
<meta name="author" content="mayar ashraf">
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">   
    
<link rel="stylesheet" href="path/to/fontawesome.min.css">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">   
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    
<link rel="stylesheet" type="text/css" href="Dactarastyle.css">
<link rel="stylesheet" type="text/css" href="Mayar192785.css">
    
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>   
<script src= "javascript.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    
    
<nav>
      <img class="logo" src="Images/LogoMakr-85XoZT.png">
      
      <div class="ham" >  
        <span class="bar1"></span>  
        <span class="bar2"></span>  
        <span class="bar3"></span>  
      </div>  

      <ul class="nav-sub">
          <li><a class="active" href="Home.php">Home</a></li>
          <li><a class="active" href="Reservation.php">Reservation</a></li>
          <li><a class="active" href="offers.php">Offers</a></li>
          <li><a class="active" href="Counsoltation.php">Counsoltation</a></li>
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
    
    <br>
    <br>
    <br>
    <br>
   
<body>

    <title>OFFERS PAGE</title>
  <h2 style="text-align: center;
    font-size: 200%;">OFFERS</h2>
  
    <br>
    <br>
    <br>
    <br>
        
<table>
    
    <tr>

        
        <td>     
  <div class = container >
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://www.dentalzorg.com/wp-content/uploads/elementor/thumbs/DentalZorg-Dubai-dental-care-package-offer-pi6ghuvsyzj40ku6t3or0w6pwz9oc01ul3t1a9z8ug.jpeg">
          
        </div>
   
              <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>

      <div class = content>
     
          <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
          <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
          <div id="promo">
          <h4>Promocode</h4>
              <button id="button1" type="button" onclick="generateString(8)">View Promocode</button>
                    
              <p>[Click to copy code]</p>
           <input id="code1"value=""> 
        <img id="img1" src="images/copy_icon.png" onclick="myFunction()">
          </div>
         
      </div>
  

    </div>    
  </div>


        </td>
        <td>
  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://www.guineydental.ie/wp-content/uploads/2021/04/128703322_s_3.jpg">
      </div>
        
        
        
       <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
        
        
        <!--reserve button-->
<div id="id01" class="modal">
  
  <form id="forms" class="modal-content animate" method="post" >
    <div class="imgcontainer">
      <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal">&times;</span>
      <img src="images/LogoMakr-85XoZT.png" alt="Avatar" class="avatar">
    </div>

    <div class="container">
      <label for="uname"><b>Name</b></label>
      <input type="text" placeholder="Enter name" name="name" >
        <br>
      <label for="psw"><b>Age</b></label>
      <input type="number" placeholder="Enter age" name="age" >
      <br>
      <label for="psw"><b>Phone Number</b></label>
      <input type="number" placeholder="Enter Phone number" name="pnum" >
      <br>
      <label for="Date"><b>Date</b></label>
      <input type="Date" placeholder="promocode" name="Date" >
      <br>
      <label for="Time"><b>Time</b></label>
      <input type="Time" placeholder="promocode" name="Time" >
      <br> 
      <label for="psw"><b>Paste promocode</b></label>
      <input type="text" placeholder="promocode" name="promo" >
      <br>
        
      <button type="submit" name="submit">Submit</button>
     
    </div>

    <div class="container" style="background-color:#f1f1f1">
      <button type="button" onclick="document.getElementById('id01').style.display='none'" class="cancelbtn">Cancel</button>
      
    </div>
    <?php
require_once('C:/aa/htdocs/GROUP_12/Admin/Admin_connect.php');
if(isset($_POST['submit'])){
$i=10;
$i=$i+1;

$reservation_ID=$i;
$reservationType=[''];
$name=$_POST['name'];
$age=$_POST['age'];
$Date=$_POST['Date'];
$Time=$_POST['Time'];


    $result = $conn->query("INSERT INTO reservation (Reservation_ID, Reservation_Type,Reservation_Time,Reservation_Date) VALUES ('$reservation_ID','$reservationType','$Date','$Time')");
    if ($result) {
     echo '<script>alert("Reserved")</script>';
    }
 
} 
?>
  </form>
</div>


  <div class = content>
          <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
          <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      
          <div id="promo">
          <h4>Promocode</h4>
                      <button id="button2" type="button" onclick="generateString(8)">View Promocode</button>
                    
              <p>[Click to copy code]</p>
           <input id="code2"value=""> 
        <img id="img2" src="images/copy_icon.png" onclick="myFunction()">
          </div>
      </div>
    </div>    
  </div>

        </td>
<td>
  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://media.istockphoto.com/photos/surgeons-perform-brain-surgery-using-augmented-reality-animated-3d-picture-id1015934084?k=20&m=1015934084&s=612x612&w=0&h=ZbSHzOHHt57iqhTxLtcleiBEToN1R0fVZ7V3YIzcMBk=">
      </div>

         <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>     
            
 <div class = content>
    <h4>Clinic: </h4>
    <p> Lou Dental clinic</p>
    <h4>Offer: </h4>
    <p> 20% discount on any dental checkup (only for new patients)</p>
    <h4>Expiry Date: </h4>
    <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
                      <button id="button3" type="button" onclick="generateString(8)">View Promocode</button>
             
          <p>[Click to copy code]</p>
           <input id="code3"value=""> 
          <img id="img3" src="images/copy_icon.png" onclick="myFunction()">
           
          </div>
      </div>
    </div>    
  </div>
        </td>
        </tr>
    <tr>
        
        <td>

  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://d5xz95ax6mbg9.cloudfront.net/images/2018/01/Pediatrician-101-Everything-You-Need-To-Know-About-Pediatricians-825x510.jpg">
      </div>
                 <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
    
 <div class = content>
    <h4>Clinic: </h4>
    <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
     <p> 20% discount on any dental checkup (only for new patients)</p>
    <h4>Expiry Date: </h4>
    <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
            <button id="button4" type="button" onclick="generateString(8)">View Promocode</button>
            
          <p>[Click to copy code]</p>
            <input id="code4"value="">
          <img id="img4" src="images/copy_icon.png" onclick="myFunction()">
          
          </div>
      </div>
    </div>    
  </div>

        
        </td>
        <td>
  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="images/dental%20offer.jpg">
      </div>
               <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
       
 <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
            <button id="button5" type="button" onclick="generateString(8)">View Promocode</button>
              
          <p>[Click to copy code]</p>
            <input id="code5"value=""> 
          <img id="img5" src="images/copy_icon.png" onclick="myFunction()">
        
          </div>
      </div>
    </div>    
  </div>

        </td>
<td>
  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://elliotphysicians.org/wp-content/uploads/2018/09/ThinkstockPhotos-508509000.jpg">
      </div>
                 <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
    
 <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
                      <button id="button6" type="button" onclick="generateString(8)">View Promocode</button>
              
          <p>[Click to copy code]</p>
           <input id="code6"value=""> 
          <img id="img6" src="images/copy_icon.png" onclick="myFunction()">
          </div>
      </div>
    </div>    
  </div>

        </td>
        </tr>
        <tr>
        
        <td>
  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://www.150harleyst.co.uk/wp-content/uploads/2020/03/nose-examination.jpg">
      </div>
                <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
     
  <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
      <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
       <div id="promo">
          <h4>Promocode</h4>
                       <button id="button7" type="button" onclick="generateString(8)">View Promocode</button>
             
           <p>[Click to copy code]</p>
           <input id="code7"value=""> 
            <img id="img7" src="images/copy_icon.png" onclick="myFunction()">
          </div>
      </div>
    </div> 

</div>
   

        
        </td>
        <td>

  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://wp02-media.cdn.ihealthspot.com/wp-content/uploads/sites/350/2018/12/17215210/iStock-842481060.jpg">
      </div>
                 <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
       
 <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
                     <button id="button8" type="button" onclick="generateString(8)">View Promocode</button>
              
          <p>[Click to copy code]</p>
           <input id="code8"value=""> 
          <img id="img8" src="images/copy_icon.png" onclick="myFunction()">
          </div>
      </div>
    </div>    
  </div>

        </td>
<td>

  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://media.istockphoto.com/photos/eye-doctor-with-female-patient-during-an-examination-in-modern-clinic-picture-id1189362136?k=20&m=1189362136&s=612x612&w=0&h=qYC-fuPQn96vMwPpOBWrQKpGB084FW3Ge329QKpGL6c=">
      </div>
               <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
      
 <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
                     <button id="button9" type="button" onclick="generateString(8)">View Promocode</button>
              
          <p>[Click to copy code]</p>
           <input id="code9"value=""> 
          <img id="img9" src="images/copy_icon.png" onclick="myFunction()">
          </div>
      </div>
    </div>    
  </div>

        </td>
        </tr>
        <tr>
        
        <td>
  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://sa1s3optim.patientpop.com/assets/images/provider/photos/2371986.jpg">
      </div>
                 <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
     
 <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
                      <button id="button10" type="button" onclick="generateString(8)">View Promocode</button>
               
          <p>[Click to copy code]</p>
           <input id="code10"value="">  
         <img id="img10" src="images/copy_icon.png" onclick="myFunction()">
          </div>
      </div>
    </div>    
  </div>

        </td>
<td>
  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://www.lonetreepediatrics.com/wp-content/uploads/2016/07/Lone-Tree-Pediatrics-Qualities.jpg">
      </div>
                 <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
     
 <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
                 <button id="button11" type="button" onclick="generateString(8)">View Promocode</button>
               
          <p>[Click to copy code]</p>
           <input id="code11"value=""> 
         <img id="img11" src="images/copy_icon.png" onclick="myFunction()">
          </div>
      </div>
    </div>    
  </div>

        </td>
            <td>

  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://www.wildflowerdentalaz.com/wp-content/uploads/2021/01/20_percent_off_treatment.png">
      </div>
                <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
   
 <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
          <button id="button12" type="button" onclick="generateString(8)">View Promocode</button>
          <p>[Click to copy code]</p>
          <input id="code12"value=""> 
          <img id="img12" src="images/copy_icon.png" onclick="myFunction()">
          </div>
      </div>
    </div>    
  </div>

        </td>
        </tr>
        <tr>
        
        <td>

  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://www.torgheledentistry.com/wp-content/uploads/2016/06/SpecialOffers-TORGHELE-50-Off.png">
      </div>
                 <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
    
 <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
          <button id="button13" type="button" onclick="generateString(8)">View Promocode</button>
          <p>[Click to copy code]</p>
          <input id="code13"value=""> 
          <img id="img13" src="images/copy_icon.png" onclick="myFunction()">
        
          </div>
      </div>
    </div>    
  </div>

        
        </td>
        <td>
            
  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src ="https://media.istockphoto.com/photos/surgical-doctor-looking-at-xray-film-picture-id840336238?k=20&m=840336238&s=612x612&w=0&h=SuPwR8Ah7uxBYgJCGYohtl5hR7Lrx4-PBJIrST-ySr4=">
      </div>
                 <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
        
 <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
                       <button id="button14" type="button" onclick="generateString(8)">View Promocode</button>
          <p>[Click to copy code]</p>
           <input id="code14"value=""> 
          <img id="img14" src="images/copy_icon.png" onclick="myFunction()">
            
          </div>
      </div>
    </div>    
  </div>

        </td>
<td>
  <div class = container>
    <div class = card>
      <div class = image>
        <img href = "#" src = "https://media.istockphoto.com/photos/portrait-of-a-happy-mature-male-patient-undergoing-vision-check-with-picture-id1279371084?k=20&m=1279371084&s=612x612&w=0&h=TjM1SyOOjJxCgCf3z2ciYXMTmfFufSzc5bp4k_goh3c=">
      </div>
                 <div class="reserve"><button onclick="document.getElementById('id01').style.display='block'" style="width:auto;">Reserve now</button>
       </div>
      
 <div class = content>
        <h4>Clinic: </h4>
          <p> Lou Dental clinic</p>
     <h4>Offer: </h4>
          <p> 20% discount on any dental checkup (only for new patients)</p>
          <h4>Expiry Date: </h4>
          <p>21/4/2022</p>
      <div id="promo">
          <h4>Promocode</h4>
                       <button id="button15" type="button" onclick="generateString(8)">View Promocode</button>
          
          <p>[Click to copy code]</p>
           <input id="code15"value=""> 
           <img id="img15" id="copy" src="images/copy_icon.png" onclick="myFunction()">
             
          </div>
      </div>
    </div>    
  </div>

        </td>
        </tr>

    </table>  
    </body>
    
 <br>
    <br>
    
<footer>
 <div class="row">
  <div class="column">
      <img src="Images/LogoMakr-85XoZT.png" width="100%">
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
    
    
    
    
    
    
    
    
    
    
    
    
    
<script>
// Get the modal
var modal = document.getElementById('id01');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
</script>
    
    
    
</html>
