<html>
<?php
include_once("Guest_nav.php");
?>
<body>
    

    <br>
    <br>
     <form name="forms" method="Post" enctype="multipart/form-data">
         <div class="dropdown">
 <ul>
     <hr>
       <li><button id="update2">New Guest ID</button></li>
      <hr>
       <li><button id="update3">Guest UserName</button></li>
     <hr>
       <li><button id="update4">Guest Password</button></li>
     <hr>
       <li><button id="update5">Guest Phone Number</button></li>
     <hr>
       <li><button id="update6">Guest Email</button> </li>  
</ul>

</div>


         <script>
         $("#update2").click(function(){
            
          if(document.getElementById("Guest_UserName").style.visibility=="visible" 
          ||document.getElementById("Guest_Password").style.visibility=="visible"
          ||document.getElementById("Guest_PhoneNumber").style.visibility=="visible"
          ||document.getElementById("Guest_Email").style.visibility=="visible"){ 

            document.getElementById("Guest_UserName").style.visibility="hidden";  
            document.getElementById("Guest_Password").style.visibility="hidden";
            document.getElementById("Guest_PhoneNumber").style.visibility="hidden";
            document.getElementById("Guest_Email").style.visibility="hidden";
 
            
            }
            else{
              document.getElementById("Guest_ID").style.visibility="visible";
              document.getElementById("newGuest_ID").style.visibility="visible";
              document.getElementById("update").style.visibility="visible";  
            }
            
             
})
        $("#update3").click(function(){
          if(document.getElementById("newGuest_ID").style.visibility=="visible" 
          ||document.getElementById("Guest_Password").style.visibility=="visible"
          ||document.getElementById("Guest_PhoneNumber").style.visibility=="visible"
          ||document.getElementById("Guest_Email").style.visibility=="visible"){
                   
            document.getElementById("newGuest_ID").style.visibility="hidden";
            document.getElementById("Guest_Password").style.visibility="hidden";
            document.getElementById("Guest_PhoneNumber").style.visibility="hidden";
            document.getElementById("Guest_Email").style.visibility="hidden";

            }        
            else{
              document.getElementById("Guest_ID").style.visibility="visible";
            document.getElementById("Guest_UserName").style.visibility="visible"; 
            document.getElementById("update").style.visibility="visible";
            }
           
            
})
        $("#update4").click(function(){
            if(document.getElementById("newGuest_ID").style.visibility=="visible" 
            ||document.getElementById("Guest_UserName").style.visibility=="visible"
            ||document.getElementById("Guest_PhoneNumber").style.visibility=="visible"
            ||document.getElementById("Guest_Email").style.visibility=="visible"){
                
            document.getElementById("newGuest_ID").style.visibility="hidden";  
            document.getElementById("Guest_UserName").style.visibility="hidden";
            document.getElementById("Guest_PhoneNumber").style.visibility="hidden";
            document.getElementById("Guest_Email").style.visibility="hidden";

            }
            else{
            document.getElementById("Guest_ID").style.visibility="visible"; 
            document.getElementById("Guest_Password").style.visibility="visible";
            document.getElementById("update").style.visibility="visible";
            }
                
            
})
        $("#update5").click(function(){
        if(document.getElementById("newGuest_ID").style.visibility=="visible"
         ||document.getElementById("Guest_UserName").style.visibility=="visible"
         ||document.getElementById("Guest_Password").style.visibility=="visible"
         ||document.getElementById("Guest_Email").style.visibility=="visible"){
                
            document.getElementById("newGuest_ID").style.visibility="hidden";  
            document.getElementById("Guest_UserName").style.visibility="hidden";
            document.getElementById("Guest_Password").style.visibility="hidden";
            document.getElementById("Guest_Email").style.visibility="hidden";
        }
            else{
            document.getElementById("Guest_ID").style.visibility="visible"; 
            document.getElementById("Guest_PhoneNumber").style.visibility="visible";
            document.getElementById("update").style.visibility="visible"; 
            }
})
        $("#update6").click(function(){
             if(document.getElementById("newGuest_ID").style.visibility=="visible" 
             ||document.getElementById("Guest_UserName").style.visibility=="visible"
             ||document.getElementById("Guest_Password").style.visibility=="visible"
             ||document.getElementById("Guest_PhoneNumber").style.visibility=="visible"){
                 
            document.getElementById("newGuest_ID").style.visibility="hidden";  
            document.getElementById("Guest_UserName").style.visibility="hidden";
            document.getElementById("Guest_Password").style.visibility="hidden";
            document.getElementById("Guest_PhoneNumber").style.visibility="hidden";
                 

             }
            else{
            document.getElementById("Guest_ID").style.visibility="visible";
            document.getElementById("Guest_Email").style.visibility="visible";
            document.getElementById("update").style.visibility="visible";
            }
})

     
         </script>
     <div name="form" class="form" >
   
    
        <h1 style="text-align: center;
    font-size: 200%;
    font-family: 'Playfair Display';
    color: #fff;">Update On Guest</h1>

      <div id="Guest_ID" class="input-container ic2">
        <input name="Guest_ID" class="input" type="text" placeholder=" " required>
        <div id="cut" class="cut1"></div>
        <label for="Guest_ID" class="placeholder">Guest ID</label>
      </div>
      <div id="newGuest_ID" class="input-container ic2">
        <input name="newGuest_ID" class="input" type="text" placeholder=" " >
        <div id="cut" class="cut1"></div>
        <label for="newGuest_ID" class="placeholder">New Guest ID</label>
      </div>

      <div id="Guest_UserName" class="input-container ic2">
        <input name="Guest_UserName" class="input" type="text" placeholder=" " />
        <div id="cut" class="cut2"></div>
        <label for="Guest_UserName" class="placeholder">Guest UserName</label>
      </div>

        <div id="Guest_Password" class="input-container ic2">
        <input name="Guest_Password" class="input" type="text" placeholder=" " />
        <div id="cut" class="cut3"></div>
        <label for="Guest_Password" class="placeholder">Guest password</label>
      </div>

        <div id="Guest_PhoneNumber" class="input-container ic2">
        <input name="Guest_PhoneNumber" class="input" type="date" placeholder=" " />
        <div id="cut" class="cut4"></div>
        <label for="Guest_PhoneNumber" class="placeholder">Guest Phone Number</label>
      </div>

        <div id="Guest_Email" class="input-container ic2">
        <input name="Guest_Email" class="input" type="text" placeholder=" " />
        <div id="cut" class="cut5"></div>
        <label for="Guest_Email" class="placeholder">Guest Email</label>
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
    #Guest_ID
    {
         visibility: hidden;
    }
    #newGuest_ID{
      visibility: hidden;
    }
    #Guest_UserName
    {
         visibility: hidden;
    }
    #Guest_Password{
         visibility: hidden;
    }
    #Guest_PhoneNumber
    {
         visibility: hidden;
    }
    #Guest_Email
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
require_once ("C:/aa/htdocs/GROUP_12/Admin/Admin_connect.php");


if (isset($_POST['update'])) {

    
  
$Guest_ID=$_POST['Guest_ID'];
$newGuest_ID=$_POST['newGuest_ID'];
$Guest_UserName=$_POST['Guest_UserName'];
$Guest_Password=$_POST['Guest_Password'];
$Guest_PhoneNumber=$_POST['Guest_PhoneNumber'];
$Guest_Email=$_POST['Guest_Email'];


$guestlist = $conn->query("SELECT * FROM guest WHERE Guest_ID='$Guest_ID'"); 
$guestdata = $guestlist->fetchALL(PDO::FETCH_ASSOC);

    if (!empty($newGuest_ID)){

      $update = "UPDATE guest SET Guest_ID='$newGuest_ID'  WHERE Guest_ID='$Guest_ID'";
    }
    if (!empty($Guest_UserName)) {
      $update = "UPDATE guest SET Guest_UserName='$Guest_UserName' WHERE Guest_ID='$Guest_ID'";
    }
    if(!empty($Guest_Password)) {
      $update = "UPDATE guest SET Guest_Password='$Guest_Password' WHERE Guest_ID='$Guest_ID'";
    }
    if(!empty($Guest_PhoneNumber)) {
      $update = "UPDATE guest SET Guest_PhoneNumber='$Guest_PhoneNumber' WHERE Guest_ID='$Guest_ID'";
    } 
    if(!empty($Guest_Email)) {
      $update = "UPDATE guest SET Guest_Email='$Guest_Email' WHERE Guest_ID='$Guest_ID'";
    }
           
      
        $result = $conn->query($update);
        if ($result) {
            echo '<script>alert("Data updated successfully")</script>';
        }
      
    
}
?>