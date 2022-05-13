
<html>
<?php
include_once("Doctor_nav.php");
?>
<body>
    
    <br>
    <br>
    <form method="Post" enctype="multipart/form-data">

     <div name="form" class="form" >
   
    
        <h1 style="text-align: center;
    font-size: 200%;
    font-family: 'Playfair Display';
    color: #fff;">Delete From Doctor</h1>
      <div id="Doctor_ID" class="input-container ic2">
        <input name="Doctor_ID" class="input" type="text" placeholder=" " required>
        <div id="cut" class="cut1"></div>
        <label for="Doctor_ID" class="placeholder">Doctor_ID</label>
      </div>
    
  
      <button type="submit" class="submit" id="delete" name="delete">DELETE</button>
   
   
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

if(isset($_POST['delete'])){

$Doctor_ID=$_POST['Doctor_ID'];


if(!empty($Doctor_ID)){
$delete="DELETE FROM doctor WHERE Doctor_ID='$Doctor_ID'";
}



$result=$conn->query($delete);

  if($result){
    echo'<script>alert("information is deleted successfully")</script>';
  }
}
 
?>