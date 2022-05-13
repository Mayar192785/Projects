<html>
<?php
include_once("Offer_nav.php");
?>
<body>

    <table>
        <caption style="text-align: center;
    font-size: 200%;
    font-family: 'Playfair Display';
    color: mediumpurple;
    size: 20px;
    margin-bottom: 3%;">OFFERS</caption>
        <tr>
            <th>Offer_ID</th>
            <th>Offer_code</th>
            <th>Specialization_Offer</th>
            <th>Offer_Percentage</th>
            <th>Expiry_Date</th>
            <th>Clinic_ID</th>
            <th>Admin_ID</th>
         
        </tr>
     
        
        <?php
  require_once ("C:/aa/htdocs/GROUP_12/Admin/Admin_connect.php");
  $result = $conn->query("SELECT * FROM offer ");  
    

  if($result){
while ($row=$result->fetch(PDO:: FETCH_ASSOC)){
    echo "<tr>
    <td>".$row["Offer_ID"]."</td>
    <td>".$row["Offer_Code"]."</td>
    <td>".$row["Offer_Specialization"]."</td>
    <td>".$row["Offer_Percentage"]."</td>
    <td>".$row["Expiration_Date"]."</td>
    <td>".$row["Clinic_ID"]."</td>
    <td>".$row["Admin_ID"]."</td>
    </tr>";
}
echo"</table>";
  }
else{
    echo "0 result";
}
            ?>
           
    </table>
</body>
<!-- <?php
    include_once("Admin_footer.php");
    ?> -->
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
    

</style>