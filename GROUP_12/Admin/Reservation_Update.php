<html>
<?php
include_once("Reservation_nav.php");
?>
<body>
    
    <br>
    <br>
    <form method="Post" enctype="multipart/form-data">
         <div class="dropdown">
 <ul>
        <li><button id="update1">New Reservation ID</button></li>
     <hr>
       <li><button id="update2">Reservation Type</button></li>
     <hr>
       <li><button id="update3">Reservation Time</button></li>
     <hr>
       <li><button id="update4">Reservation Date</button></li>
    
</ul>

</div>
      <script>
         $("#update1").click(function(){
               if(document.getElementById("Reservation_Type").style.visibility=="visible" ||document.getElementById("Reservation_Time").style.visibility=="visible"||document.getElementById("Reservation_Date").style.visibility=="visible"){
                   
            document.getElementById("Reservation_Type").style.visibility="hidden";  
            document.getElementById("Reservation_Time").style.visibility="hidden";
            document.getElementById("Reservation_Date").style.visibility="hidden";

            
               }
             else{
                document.getElementById("Reservation_ID").style.visibility="visible";
                document.getElementById("newReservation_ID").style.visibility="visible";
                document.getElementById("update").style.visibility="visible";  
             }
})
        $("#update2").click(function(){
            if(document.getElementById("newReservation_ID").style.visibility=="visible"||document.getElementById("Reservation_Time").style.visibility=="visible"||document.getElementById("Reservation_Date").style.visibility=="visible"){

            document.getElementById("newReservation_ID").style.visibility=="hidden";       
            document.getElementById("Reservation_Time").style.visibility="hidden";
            document.getElementById("Reservation_Date").style.visibility="hidden";

                    }
            else{
            document.getElementById("Reservation_ID").style.visibility="visible";
            document.getElementById("Reservation_Type").style.visibility="visible"; 
            document.getElementById("update").style.visibility="visible";
            }
})

        $("#update3").click(function(){
        if(document.getElementById("newReservation_ID").style.visibility=="visible"||document.getElementById("Reservation_Type").style.visibility=="visible" ||document.getElementById("Reservation_Date").style.visibility=="visible"){
          
          document.getElementById("newReservation_ID").style.visibility=="hidden";   
            document.getElementById("Reservation_Type").style.visibility="hidden";  
            document.getElementById("Reservation_Date").style.visibility="hidden";
        }
            else{
            document.getElementById("Reservation_ID").style.visibility="visible"; 
            document.getElementById("Reservation_Time").style.visibility="visible";
            document.getElementById("update").style.visibility="visible"; 
            }
})
        $("#update4").click(function(){
             if(document.getElementById("newReservation_ID").style.visibility=="visible"||document.getElementById("Reservation_Type").style.visibility=="visible" ||document.getElementById("Reservation_Time").style.visibility=="visible"){
                 
              document.getElementById("newReservation_ID").style.visibility=="hidden";
            document.getElementById("Reservation_Type").style.visibility="hidden";  
            document.getElementById("Reservation_Time").style.visibility="hidden";
                 

             }
            else{
            document.getElementById("Reservation_ID").style.visibility="visible";
            document.getElementById("Reservation_Date").style.visibility="visible";
            document.getElementById("update").style.visibility="visible";
            }
})
     
         </script>

  
     <div name="form" class="form" >
   
    
        <h1 style="text-align: center;
    font-size: 200%;
    font-family: 'Playfair Display';
    color: #fff;">Update a Reservation</h1>
      <div id="Reservation_ID" class="input-container ic2">
        <input name="Reservation_ID" class="input" type="text" placeholder=" " required>
        <div id="cut" class="cut1"></div>
        <label for="Reservation_ID" class="placeholder">Reservation ID</label>
      </div>
      <div id="newReservation_ID" class="input-container ic2">
        <input name="newReservation_ID" class="input" type="text" placeholder=" " required>
        <div id="cut" class="cut1"></div>
        <label for="newReservation_ID" class="placeholder">New Reservation ID</label>
      </div>
      <div id="Reservation_Type" class="input-container ic2">
        <input name="Reservation_Type" class="input" type="text" placeholder=" " required/>
        <div id="cut" class="cut2"></div>
        <label for="Reservation_Type" class="placeholder">Reservation Type</label>
      </div>
        <div id="Reservation_Time" class="input-container ic2">
        <input name="Reservation_Time" class="input" type="time" placeholder=" " required/>
        <div id="cut" class="cut3"></div>
        <label for="Reservation_Time" class="placeholder">Reservation Time</label>
      </div>
        <div id="Reservation_Date" class="input-container ic2">
        <input name="Reservation_Date" class="input" type="date" placeholder=" " required/>
        <div id="cut" class="cut4"></div>
        <label for="Reservation_Date" class="placeholder">Reservation Date</label>
      </div>
      <button type="submit" class="submit" id="update" name="update">UPDATE</button>
  
     
   
   
  </div>
     </form>                  
    </body>
    <!-- <?php
    include_once("Admin_footer.php");
    ?> -->
</html>

<style>
 body{
background-image: url(https://cdn.wallpapersafari.com/8/37/AcPoTn.jpg);
}
    
.form {
  border-radius: 20px;
  box-sizing: border-box;
  padding: 20px;
  width: 320px;
  background-color: #78c1ff;
  margin-left: 25%;
  width: 50%;
  height: 100%;
   

}
    #Reservation_ID
    {
         visibility: hidden;
    }
    #newReservation_ID{
      visibility: hidden;
    }
    #Reservation_Date
    {
         visibility: hidden;
    }
    #Reservation_Time{
         visibility: hidden;
    }
    #Reservation_Type
    {
         visibility: hidden;
    }


    #update
    {
         visibility: hidden;
    }
    .dropdown {
        position: absolute;
        display: inline-block;
        text-align: center;
        margin-left: 50px;
}
    .dropdown button{
        color:mediumpurple;
        background-color: transparent;
        border: #78c1ff;
        margin: 5px;
        padding: 7px;
        font-weight: bolder;
        font-size: 1.5vw;
    }
    .dropdown button:hover{
        cursor: pointer;
    }


.input-container {
  height: 50px;
  position: relative;
  width: 100%;
}

.ic1 {
  margin-top: 40px;
}

.ic2 {
  margin-top: 30px;
}

.input {
  background-color: #fff;
  border-radius: 12px;
  border: 0;
  box-sizing: border-box;
  color: #000;
  font-size: 18px;
  height: 100%;
  outline: 0;
  padding: 4px 20px 0;
  width: 100%;
}

.cut1 {
  background-color: mediumpurple;
  border-radius: 10px;
  height: 50%;
  margin-left:20px;
  position: absolute;
  top:-15px;
  transition: transform 200ms;
    width:10%;
}
.cut2 {
  background-color: mediumpurple;
  border-radius: 10px;
  height: 50%;
  margin-left: 20px;
  position: absolute;
  top: -15px;
  transition: transform 200ms;
    width:20%;
}
.cut3 {
  background-color: mediumpurple;
  border-radius: 10px;
  height: 50%;
  margin-left: 20px;
  position: absolute;
  top: -15px;
  transition: transform 200ms;
    width:20%;
}
.cut4 {
  background-color: mediumpurple;
  border-radius: 10px;
  height: 50%;
  margin-left: 20px;
  position: absolute;
  top: -15px;
  transition: transform 200ms;
    width:15%;
}
.cut5 {
  background-color: mediumpurple;
  border-radius: 10px;
  height: 50%;
  margin-left: 20px;
  position: absolute;
  top: -15px;
  transition: transform 200ms;
    width:13%;
}


.placeholder {
  color: #65657b;
  font-family: sans-serif;
  left: 20px;
  line-height: 14px;
  pointer-events: none;
  position: absolute;
  transform-origin: 0 50%;
  transition: transform 200ms, color 200ms;
  top: 20px;
}

.input:focus ~ .placeholder,
.input:not(:placeholder-shown) ~ .placeholder {
  transform: translateY(-30px) translateX(10px) scale(0.75);
}



.input:focus ~ .placeholder {
  color: #fff;
}

.submit {
  background-color:mediumpurple;
  border-radius: 12px;
  border: 0;
  box-sizing: border-box;
  color: #eee;
  cursor: pointer;
  font-size: 18px;
  height: 50px;
  margin-top: 38px;
  text-align: center;
  width: 100%;
  color: #fff;
}

.submit:active {
  background-color: #78c1ff;
}
</style>

<?php
require_once("C:/aa/htdocs/GROUP_12/Admin/Admin_connect.php");

if(isset($_POST['update'])){

$Reservation_ID=$_POST['Reservation_ID'];
$newReservation_ID=$_POST['newReservation_ID'];
$Reservation_Type=$_POST['Reservation_Type'];
$Reservation_Time=$_POST['Reservation_Time'];
$Reservation_Date=$_POST['Reservation_Date'];

$reservationlist = $conn->query("SELECT * FROM reservation WHERE Reservation_ID='$Reservation_ID'"); 
$reservationdata = $reservationlist->fetchALL(PDO::FETCH_ASSOC);

    if (!empty($newReservation_ID)){
      $update = "UPDATE reservation SET Reservation_ID='$newReservation_ID' WHERE Reservation_ID='$Reservation_ID'";
    }
    if (!empty($Reservation_Type)) {
      $update = "UPDATE reservation SET Reservation_Type='$Reservation_Type' WHERE Reservation_ID='$Reservation_ID'";
    }
    if(!empty($Reservation_Time)) {
      $update = "UPDATE reservation SET Reservation_Time='$Reservation_Time' WHERE Reservation_ID='$Reservation_ID'";
    }
    if(!empty($Reservation_Date)) {
      $update = "UPDATE reservation SET Reservation_Date='$Reservation_Date' WHERE Reservation_ID='$Reservation_ID'";
    } 
  

    $result = $conn->query($update);
  if ($result) {
     echo '<script>alert("Reservation is Updated!")</script>';
    }
 
} 
?>
