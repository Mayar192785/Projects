<?php
try {
    $conn = new PDO("mysql:host=localhost; dbname=dactara", "root", "");
} catch (PDOException $e) {
    echo $e->getMessage();
    exit();
}
?>
