<?php

try {
    $conn = new PDO("mysql:host=localhost;dbname=dactara", "root", "");
    $doctorList= $conn->query("SELECT * FROM doctor "); // object
    $doctorData = $doctorList->fetchAll(PDO::FETCH_ASSOC); // assoc array 

} catch (PDOException $e) {
    echo $e->getMessage();
    exit();
} ?>

<head>
    <title>View Doctors</title>
    <?php
include_once("Doctor_nav.php");
?>
</head>

<body>

    <br>
    <br>
<table>
  <tr>
    <th>Doctor_ID</th>
    <th>Doctor_Name</th>
    <th>Doctor_Specialization</th>
    <th>Doctor_PhoneNumber</th>
    <th>Doctor_Email</th>
    <th>Detection_Price</th>
    <th>Doctor_ClinicName</th> 
    <th>Clinic_ID</th>
      
  </tr>
  <?php foreach ($doctorData as $doctor) { ?>
             
             <tr>
                <td><?php echo $doctor['Doctor_ID'] ?></td>
                <td><?php echo $doctor['Doctor_Name'] ?></td>
                 <td><?php echo $doctor['Doctor_Specialization'] ?></td>
                 <td><?php echo $doctor['Doctor_PhoneNumber'] ?></td>
                 <td><?php echo $doctor['Doctor_Email'] ?></td>
                 <td><?php echo $doctor['Detection_Price'] ?></td>
                 <td><?php echo $doctor['Doctor_ClinicName'] ?></td>
                 <td><?php echo $doctor['Clinic_ID'] ?></td>
             
            <?php } ?>
             
            </tr>
            
            </table>



</body>
<!-- <?php
    include_once("Admin_footer.php");
    ?>   -->
</html>
<style>
 body{
background-image: url(https://cdn.wallpapersafari.com/8/37/AcPoTn.jpg);

}
caption{
    margin-bottom:3%;
    
}
table{
    text-align: center;
    margin:auto;
    /* margin-top:2%; */
    background-color:#fff;
    border: 1px solid;
    width: 100%;
    height:60%;
}
th{
    margin-right:3%;
}
th,td,tr{
    border: 1px solid;
}
tr{
background-color: mediumpurple;

}
td{
    background-color:#fff;
}

/* tr:nth-child(even) {
  background-color: powderblue;
} */
</style>