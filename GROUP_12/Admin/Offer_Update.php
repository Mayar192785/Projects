<html>
<?php
include_once("Offer_nav.php");
?>
<body>
    

    <br>
    <br>
     <form name="forms" method="Post" enctype="multipart/form-data">
         <div class="dropdown">
 <ul>
        <!-- <li><button id="update1">Offer ID</button></li>
      <hr> -->
     <hr>
       <li><button id="update2">New Offer ID</button></li>
      <hr>
       <li><button id="update3">Specialization Offer</button></li>
     <hr>
       <li><button id="update4">Offer Percentage</button></li>
     <hr>
       <li><button id="update5">Expiry Date</button></li>
     <hr>
       <li><button id="update6">Offer code</button> </li>  
 

</ul>

</div>


         <script>
         $("#update2").click(function(){
            
          if(document.getElementById("Specialization_Offer").style.visibility=="visible" ||document.getElementById("Expiry_Date").style.visibility=="visible"||document.getElementById("Offer_code").style.visibility=="visible"||document.getElementById("Offer_Percentage").style.visibility=="visible"){ 

            document.getElementById("Specialization_Offer").style.visibility="hidden";  
            document.getElementById("Expiry_Date").style.visibility="hidden";
            document.getElementById("Offer_code").style.visibility="hidden";
            document.getElementById("Offer_Percentage").style.visibility="hidden";
 
            
            }
            else{
              document.getElementById("Offer_ID").style.visibility="visible";
              document.getElementById("newOffer_ID").style.visibility="visible";
              document.getElementById("update").style.visibility="visible";  
            }
            
             
})
        $("#update3").click(function(){
          if(document.getElementById("newOffer_ID").style.visibility=="visible" ||document.getElementById("Expiry_Date").style.visibility=="visible"||document.getElementById("Offer_code").style.visibility=="visible"||document.getElementById("Offer_Percentage").style.visibility=="visible"){
                   
            document.getElementById("Expiry_Date").style.visibility="hidden";
            document.getElementById("Offer_code").style.visibility="hidden";
            document.getElementById("Offer_Percentage").style.visibility="hidden";
            document.getElementById("newOffer_ID").style.visibility="hidden";

            }        
            else{
              document.getElementById("Offer_ID").style.visibility="visible";
            document.getElementById("Specialization_Offer").style.visibility="visible"; 
            document.getElementById("update").style.visibility="visible";
            }
           
            
})
        $("#update4").click(function(){
            if(document.getElementById("Specialization_Offer").style.visibility=="visible" ||document.getElementById("Expiry_Date").style.visibility=="visible"||document.getElementById("Offer_code").style.visibility=="visible"||document.getElementById("newOffer_ID").style.visibility=="visible"){
                
            document.getElementById("Specialization_Offer").style.visibility="hidden";  
            document.getElementById("Expiry_Date").style.visibility="hidden";
            document.getElementById("Offer_code").style.visibility="hidden";
            document.getElementById("newOffer_ID").style.visibility="hidden";

            }
            else{
            document.getElementById("Offer_ID").style.visibility="visible"; 
            document.getElementById("Offer_Percentage").style.visibility="visible";
            document.getElementById("update").style.visibility="visible";
            }
                
            
})
        $("#update5").click(function(){
        if(document.getElementById("Specialization_Offer").style.visibility=="visible" ||document.getElementById("Offer_Percentage").style.visibility=="visible"||document.getElementById("Offer_code").style.visibility=="visible"||document.getElementById("newOffer_ID").style.visibility=="visible"){
                
            document.getElementById("Specialization_Offer").style.visibility="hidden";  
            document.getElementById("Offer_Percentage").style.visibility="hidden";
            document.getElementById("Offer_code").style.visibility="hidden";
            document.getElementById("newOffer_ID").style.visibility="hidden";
        }
            else{
            document.getElementById("Offer_ID").style.visibility="visible"; 
            document.getElementById("Expiry_Date").style.visibility="visible";
            document.getElementById("update").style.visibility="visible"; 
            }
})
        $("#update6").click(function(){
             if(document.getElementById("Specialization_Offer").style.visibility=="visible" ||document.getElementById("Offer_Percentage").style.visibility=="visible"||document.getElementById("Expiry_Date").style.visibility=="visible"||document.getElementById("newOffer_ID").style.visibility=="visible"){
                 
            document.getElementById("Specialization_Offer").style.visibility="hidden";  
            document.getElementById("Offer_Percentage").style.visibility="hidden";
            document.getElementById("Expiry_Date").style.visibility="hidden";
            document.getElementById("newOffer_ID").style.visibility="hidden";
                 

             }
            else{
            document.getElementById("Offer_ID").style.visibility="visible";
            document.getElementById("Offer_code").style.visibility="visible";
            document.getElementById("update").style.visibility="visible";
            }
})

     
         </script>
     <div name="form" class="form" >
   
    
        <h1 style="text-align: center;
    font-size: 200%;
    font-family: 'Playfair Display';
    color: #fff;">Update On Offer</h1>

      <div id="Offer_ID" class="input-container ic2">
        <input name="Offer_ID" class="input" type="text" placeholder=" " required>
        <div id="cut" class="cut1"></div>
        <label for="Oferr_ID" class="placeholder">Offer ID</label>
      </div>
      <div id="newOffer_ID" class="input-container ic2">
        <input name="newOffer_ID" class="input" type="text" placeholder=" " >
        <div id="cut" class="cut1"></div>
        <label for="newOffer_ID" class="placeholder">New Offer ID</label>
      </div>

      <div id="Specialization_Offer" class="input-container ic2">
        <input name="Specialization_Offer" class="input" type="text" placeholder=" " />
        <div id="cut" class="cut2"></div>
        <label for="Specialization_Offer" class="placeholder">Specialization Offer</label>
      </div>

        <div id="Offer_Percentage" class="input-container ic2">
        <input name="Offer_Percentage" class="input" type="text" placeholder=" " />
        <div id="cut" class="cut3"></div>
        <label for="Offer_Percentage" class="placeholder">Offer Percentage</label>
      </div>

        <div id="Expiry_Date" class="input-container ic2">
        <input name="Expiry_Date" class="input" type="date" placeholder=" " />
        <div id="cut" class="cut4"></div>
        <label for="Expiry_Date" class="placeholder">Expiry Date</label>
      </div>

        <div id="Offer_code" class="input-container ic2">
        <input name="Offer_code" class="input" type="text" placeholder=" " />
        <div id="cut" class="cut5"></div>
        <label for="Offer_code" class="placeholder">Offer code</label>
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
    #offer_ID
    {
         visibility: hidden;
    }
    #newOffer_ID{
      visibility: hidden;
    }
    #Specialization_Offer
    {
         visibility: hidden;
    }
    #Offer_Percentage{
         visibility: hidden;
    }
    #Expiry_Date
    {
         visibility: hidden;
    }
    #Offer_code
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

    
  
$Offer_ID=$_POST['Offer_ID'];
$newOffer_ID=$_POST['newOffer_ID'];
$Offer_code=$_POST['Offer_code'];
$Specialization_Offer=$_POST['Specialization_Offer'];
$Offer_Percentage=$_POST['Offer_Percentage'];
$Expiry_Date=$_POST['Expiry_Date'];


$offerlist = $conn->query("SELECT * FROM offer WHERE Offer_ID='$Offer_ID'"); 
$offerdata = $offerlist->fetchALL(PDO::FETCH_ASSOC);

    if (!empty($newOffer_ID)){
      $update = "UPDATE offer SET Offer_ID='$newOffer_ID' WHERE Offer_ID='$Offer_ID'";
    }
    if (!empty($Offer_code)) {
      $update = "UPDATE offer SET Offer_Code='$Offer_code' WHERE Offer_ID='$Offer_ID'";
    }
    if(!empty($Specialization_Offer)) {
      $update = "UPDATE offer SET Offer_Specialization='$Specialization_Offer' WHERE Offer_ID='$Offer_ID'";
    }
    if(!empty($Offer_Percentage)) {
      $update = "UPDATE offer SET Offer_Percentage='$Offer_Percentage' WHERE Offer_ID='$Offer_ID'";
    } 
    if(!empty($Expiry_Date)) {
      $update = "UPDATE offer SET Expiration_Date='$Expiry_Date' WHERE Offer_ID='$Offer_ID'";
    }
           
      
        $result = $conn->query($update);
        if ($result) {
            echo '<script>alert("Data updated successfully")</script>';
        }
      
    
}
?>