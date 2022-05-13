<?php
if (isset($_GET['Doctor_ID'])) {
    $Doctor_ID = $_GET['Doctor_ID'];
} else {
    $Doctor_ID = 0;
}
try {
    $conn = new PDO("mysql:host=localhost;dbname=dactara", "root", "");
    $doctorList = $conn->query("SELECT * FROM doctor WHERE Doctor_ID='$Doctor_ID'"); //object
    $doctorData = $doctorList->fetch(PDO::FETCH_ASSOC);
} catch (PDOException $e) {
    echo $e->getMessage();
    exit();
} ?>

<?php
if (isset($_POST['submit'])) {
    function validate($input)
    {
        $data = trim($input);
        $data = stripslashes($data);
        $data = htmlspecialchars($data);
        return $data;
    }
    
   $Doctor_ID = validate($_POST['Doctor_ID']);
    $Doctor_Name = validate($_POST['Doctor_Name']);
    $Doctor_Specialization = validate($_POST['Doctor_Specialization']);
    $Doctor_PhoneNumber = validate($_POST['Doctor_PhoneNumber']);
    $Doctor_Email = validate($_POST['Doctor_Email']);
    $Detection_Price = validate($_POST['Detection_Price']);
$Doctor_ClinicName = validate($_POST['Doctor_ClinicName']);
$Clinic_ID = validate($_POST['Clinic_ID']);    
    
    if (!empty($Doctor_ID) && !empty($Doctor_Name) && !empty($Doctor_Specialization)&& !empty($Doctor_PhoneNumber)&& !empty($Doctor_Email)&& !empty($Detection_Price)&& !empty($Doctor_ClinicName)&& !empty($Clinic_ID)){
       $updatedoctor="UPDATE doctor SET Doctor_ID='$Doctor_ID',Doctor_Name='$Doctor_Name',Doctor_Specialization='$Doctor_Specialization',Doctor_PhoneNumber='$Doctor_PhoneNumber',
Doctor_Email='$Doctor_Email',Detection_Price='$Detection_Price',Doctor_ClinicName='$Doctor_ClinicName', Clinic_ID ='$Clinic_ID' WHERE Doctor_ID='$Doctor_ID'"; 
     $result = $conn->query($updatedoctor);
        if ($result) {
            echo "done";
        }
   }
        }


?>
<html>
<?php
include_once("Doctor_nav.php");
?>
   

    <body>

    <br>
    <br>
    <form method="POST" enctype="multipart/form-data">
    <div class="form">
        <div class="container">
      <div class="title">Edit Doctor Data</div>
      <div class="input-container ic1">
        <input id="Doctor Name" name="Doctor_Name" class="input" type="text" placeholder=" " />
        <div class="cut"></div>
        <label for="Doctor Name" class="placeholder">Doctor Name</label>
      </div>
      <div class="input-container ic2">
        <input id="Doctor ID" class="input" name="Doctor_ID" type="text" placeholder=" " />
        <div class="cut"></div>
        <label for="Doctor ID" class="placeholder">Doctor ID</label>
      </div>
      <div class="input-container ic2">
        <input id="Doctor Specialization" class="input" name="Doctor_Specialization" type="text" placeholder=" " />
        <div class="cut cut-short"></div>
        <label for="Doctor Specialization" class="placeholder">Doctor Specialization</label>
      </div>
            <div class="input-container ic2">
        <input id="Doctor PhoneNumber" class="input" name="Doctor_PhoneNumber" type="text" placeholder=" " />
        <div class="cut cut-short"></div>
        <label for="Doctor PhoneNumber" class="placeholder">Doctor PhoneNumber</label>
      </div>
             <div class="input-container ic2">
        <input id="Doctor Email" class="input" name="Doctor_Email" type="text" placeholder=" " />
        <div class="cut cut-short"></div>
        <label for="Doctor Email" class="placeholder">Doctor Email</label>
      </div>
             <div class="input-container ic2">
        <input id="Doctor's PHD" class="input" name="" type="text" placeholder=" " />
        <div class="cut cut-short"></div>
        <label for="Doctor's PHD" class="placeholder">Doctor's PHD</label>
      </div>
             <div class="input-container ic2">
        <input id="Doctor ClinicName" class="input" name="Doctor_ClinicName" type="text" placeholder=" " />
        <div class="cut cut-short"></div>
        <label for="Doctor ClinicName" class="placeholder">Doctor ClinicName</label>
      </div>
             <div class="input-container ic2">
        <input id="Detection Price" class="input" name="Detection_Price" type="text" placeholder=" " />
        <div class="cut cut-short"></div>
        <label for="Detection Price" class="placeholder">Detection Price</label>
      </div>
             <div class="input-container ic2">
        <input id="Doctor PhoneNumber" class="input" name="Clinic_ID" type="text" placeholder=" " />
        <div class="cut cut-short"></div>
                 <label for="Doctor PhoneNumber" class="placeholder">Clinic ID</label>
      </div>
      <button type="text" class="submit" name="submit">Edit</button>
    </div>
        </div>
</form>
    </body>
    <!-- <?php
    include_once("Admin_footer.php");
    ?> -->
</html>
<style>
body {
padding: 0;
	margin: 0;
	font-family: 'Roboto Condensed', sans-serif;
}

.form {
 background: url(images/BG.jpg) no-repeat;
	background-size: cover;
    min-height: 100vh;
    color: white;
	background-position:center;
	padding-top: 30px;	
}

.title {
  color: whitesmoke;
  font-family: sans-serif;
  font-size: 36px;
  font-weight: 600;
  margin-top: 30px;
    text-align: center
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
  background-color: whitesmoke;
  border-radius: 12px;
  border: 0;
  box-sizing: border-box;
  color: #eee;
  font-size: 18px;
  height: 100%;
  outline: 0;
  padding: 4px 20px 0;
  width: 100%;
}

.cut {
  background-color: mediumpurple;
  border-radius: 10px;
  height: 20px;
  left: 20px;
  position: absolute;
  top: -20px;
  transform: translateY(0);
  transition: transform 200ms;
  width: 90px;
}

.cut-short {
  width: 120px;
}

.input:focus ~ .cut,
.input:not(:placeholder-shown) ~ .cut {
  transform: translateY(8px);
}

.placeholder {
  color: #65657b;
  font-family: sans-serif;
  left: 20px;
  line-height: 20px;
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

.input:not(:placeholder-shown) ~ .placeholder {
  color: #808097;
}

.input:focus ~ .placeholder {
  color: whitesmoke;
}

.submit {
  background-color: mediumpurple;
  border-radius: 12px;
  border: 0;
  box-sizing: border-box;
  color: #eee;
  cursor: pointer;
  font-size: 18px;
  height: 50px;
  margin-top: 38px;
  // outline: 0;
  text-align: center;
  width: 100%;
}

.submit:active {
  background-color: #06b;
}
    .container {
	width: 620px;
    margin: auto;
    padding: 30px 30px 20px;
    box-sizing: border-box;
    background-color: #78c1ff;
}
</style>