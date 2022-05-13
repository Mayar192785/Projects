<html>
<?php
include_once("Guest_nav.php");
?>
<body>

    
    <table>
        <caption style="text-align: center;
            font-size: 200%;
            font-family: 'Playfair Display';
            color: mediumpurple;
            size: 20px;
            margin-bottom: 3%;">GUEST</caption>
        <tr>
            <th>Guest_ID</th>
            <th>Guest_Username</th>
            <th>Guest_Password</th>
            <th>Guest_Email</th>
            <th>Guest_PhoneNumber</th>   
        </tr>
     
        
<?php
      require_once ("C:/aa/htdocs/GROUP_12/Admin/Admin_connect.php");
      $result = $conn->query("SELECT * FROM guest ");  


      if($result){
    while ($row=$result->fetch(PDO:: FETCH_ASSOC)){
        echo
            "<tr>
            <td>".$row["Guest_ID"]."</td>
            <td>".$row["Guest_Username"]."</td>
            <td>".$row["Guest_Password"]."</td>
            <td>".$row["Guest_Email"]."</td>
            <td>".$row["Guest_PhoneNumber"]."</td>
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