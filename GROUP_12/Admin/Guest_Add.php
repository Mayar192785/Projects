<html>
<?php
include_once("Guest_nav.php");
?>
<body>
    <br>
    <br>
     <form  method="Post" enctype="multipart/form-data">
     <div name="form" class="form">
   
    
        <h1 style="text-align: center;
    font-size: 200%;
    font-family: 'Playfair Display';
    color: #fff;">Add to Guest</h1>
      <div name="Guest_ID" class="input-container ic2">
        <input name="Guest_ID" class="input" type="number" placeholder=" " required>
        <div id="cut" class="cut1"></div>
        <label for="Guest_ID" class="placeholder">Guest ID</label>
      </div>
      <div class="input-container ic2">
        <input name="Guest_UserName" class="input" type="text" placeholder=" " required/>
        <div id="cut" class="cut2"></div>
        <label for="Guest_UserName" class="placeholder">Guest UserName</label>
      </div>
        <div class="input-container ic2">
        <input name="Guest_Password" class="input" type="password" placeholder=" " required/>
        <div id="cut" class="cut3"></div>
        <label for="Guest_Password" class="placeholder">Guest Password</label>
      </div>
      <div class="input-container ic2">
        <input name="Guest_PhoneNumber" class="input" type="number" placeholder=" " required/>
        <div id="cut" class="cut5"></div>
        <label for="Guest_PhoneNumber" class="placeholder">Guest Phone Number</label>
      </div>
        <div class="input-container ic2">
        <input name="Guest_Email" class="input" type="email" placeholder=" " required/>
        <div id="cut" class="cut4"></div>
        <label for="Guest_Email" class="placeholder">Guest Email</label>
      </div>
       
 
      <button type="submit" class="submit" name="Add" >ADD</button>
  
     
   
   
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
require_once('C:/aa/htdocs/GROUP_12/Admin/Admin_connect.php');
if(isset($_POST['Add'])){

$Guest_ID=$_POST['Guest_ID'];
$Guest_UserName=$_POST['Guest_UserName'];
$Guest_Password=$_POST['Guest_Password'];
$Guest_PhoneNumber=$_POST['Guest_PhoneNumber'];
$Guest_Email=$_POST['Guest_Email'];


    $result = $conn->query("INSERT INTO guest (Guest_ID, Guest_UserName,Guest_Password, Guest_PhoneNumber, Guest_Email) VALUES ('$Guest_ID','$Guest_UserName','$Guest_Password','$Guest_PhoneNumber','$Guest_Email')");

    if ($result) {
     echo '<script>alert("Guest added successfully")</script>';
    }
 
} 
?>