<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
    
        <title>Counsoltation</title>
        
        
      <link rel="stylesheet" href="path/to/fontawesome.min.css">
    
    
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
        <script src="javascript.js"></script>
        
        <!--css file-->
        <link rel="stylesheet" href="Salma202235.css">
        <link rel="stylesheet" href="Dactarastyle.css">
        <!--font awesome icons file-->
        <script src="https://kit.fontawesome.com/a076d05399.js" ></script>
    
    
        <!--slider file-->
        <link rel="stylesheet" href="https://unpkg.com/swiper@8/swiper-bundle.min.css"/>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
        
    </head>
<body>

    <nav>
        <img class="logo" src="Images/LogoMakr-85XoZT.png">
        
        <ul>
            <li><a class="active" href="Home.php">Home</a></li>
            <li><a class="active" href="Reservation.php">Reservation</a></li>
            <li><a class="active" href="offers.php">Offers</a></li>
            <li><a class="active" href="Counsoltation.php">Counsoltation</a></li>
            <li><a class="active" href="aboutus.html">About US</a></li>
            <li><a href="login.html" class="btn btn-outline-light btn-rounded" style="border-radius: 100px;" >Sign up / log in</a></li> 
        </ul>
    </nav>
    <div class="wrapper">
        <div class="container">
            <div class="left">
                <div class="top">
                    <input type="text" placeholder="Search" />
                    <a href="javascript:;" class="search"></a>
                </div>
                <ul class="people">
                    <li class="person" data-chat="person1">
                        <img src="Images/Dr5.png" alt="" />
                        <span class="name" id="name1" onclick="name()">DR.Sherif</span>
                        <span class="time">1:00 to 3:00</span>
                        <span class="preview">Consultant of Obstetrics</span>
                    </li>
                    <li class="person" data-chat="person2">
                        <img src="images/dr1.png" alt="" />
                        <span class="name" id="name2" onclick="name()">DR.Abeer</span>
                        <span class="time">2:00 to 4:00 </span>
                        <span class="preview">Consultant of Orthopedics</span>
                    </li>
                    <li class="person" data-chat="person3">
                        <img src="images/dr3.jpg" alt="" />
                        <span class="name" id="name3" onclick="name()">DR.Mohamed</span>
                        <span class="time">3:00 to 5:00</span>
                        <span class="preview">Consultant of Obstetrics</span>
                    </li>
                    <li class="person" data-chat="person4">
                        <img src="images/dr4.png" alt="" />
                        <span class="name" id="name4" onclick="name()">DR.Habiba</span>
                        <span class="time">5:30 to 7:00</span>
                        <span class="preview">Consultant of physiotherapy</span>
                    </li>
                    <li class="person" data-chat="person5">
                        <img src="images/dr2.webp" alt="" />
                        <span class="name" id="name5" onclick="name()">DR.Adel</span>
                        <span class="time">8:00 to 9:30</span>
                         <span class="preview">Consultant of Dermatology</span>
                     
                    </li>
                    <li class="person" data-chat="person6">
                        <img src="images/dr6.jpg" alt="" />
                        <span class="name" id="name6" onclick="name()">DR.Yousef</span>
                        <span class="time">3:00 to 5:00</span>
                        <span class="preview">consultant of hepatology</span>
        
                    </li>
                </ul>
            </div>
            <div class="right">
                 <span class="name">A Telehealth Consultation Chat with the best Doctors</span>
                <div id="top1" class="top"></div>
               
                <!--<div class="write" type="text" placeholder="Send a message...">-->
                    <input type="text" class="write" placeholder="Send a message...">
                    <a href="javascript:;" class="write-link attach"></a>
                    <!--<input type="text" />-->
                    <a href="javascript:;" class="write-link smiley"></a>
                    <a href="javascript:;" class="write-link send"></a>
                </div>
            </div>
        </div>     
    <br>
    <br>
    
    
    <div class="title">
<h1>You can buy your treatment from here</h1>
</div>

<div class="box-wrapper">
<div class="box">
<img src="images/ezaby.png" width="100%" height="300">
<button class="openBtn" onclick="my()">show details</button>
</div>
<div id="popup" class="popup">
<div class="popup-content">
<h2>Here is all the information</h2>
<p>-Head Office(Working hours: 08:00 am to 04:30 pm Sunday to Thursday) <br>
.Address:6C, Takseem Asmaa Fahmy Division, Ard El Golf Heliopolis, Cairo <br>
.Telephone:02 24141445 <br>
.Fax:02 2290 1080 <br>
.Email:contactus@elezabypharmacy.com <br>


Hours of Operation: <br>
El Ezaby Pharmacy serves customers 24 hours a day, 7 days a week, through our 90 branches and unparallelled delivery services. <br>

Please see our store locator for a branch near you or call our hotline (19600) for nationwide delivery 24/7.
</p>
<a class="closeBtn" href="javascript:void(0)">x</a> 
</div>
</div>

    
<div class="box_1">
<img src="images/Roshdy%20pharmacy.jfif" width="100%" height="300">
<button class="openBtn_1" onclick="my()">show details</button>
</div>
<div id="popup_1" class="popup_1">
<div class="popup-content_1">
<h2>Here is all the information</h2>
<p>.Founded:2008 <br>
.Address: 214B hadayeq Al-Ahram - Giza, Egypt <br>
-.elephone: +20233777342</p>
<a class="closeBtn_1" href="javascript:void(0)">x</a> 
</div>
</div>


<div class="box_2">
<img src="images/ezzeldin%20pharmacy.png" width="100%" height="300">
<button class="openBtn_2" onclick="my()">show details</button>
</div>
</div>
<div id="popup_2" class="popup_2">
<div class="popup-content_2">
<h2>Here is all the information</h2>
<p>It's easy to contact our customer care department, please see the contact details below... <br>

.Easy Call Number (within Egypt): 19345 <br>

.Chat:WhatsApp Customer Care Line<br>

.Email:CustomerCare@ezzEldin.com.eg<br>

.Address: Plot 6 A / 18, Intersection of 253 Street and 205 Street, Degla, Maadi, Cairo, Egypt.</p>
<a class="closeBtn_2" href="javascript:void(0)">x</a>
</div>
</div>
    <footer>
        <div class="row">
         <div class="column">
             <img src="Images/LogoMakr-85XoZT.png" width="100%">
            </div>  
            
          <div class="column">
             <ul>
                  <li><h4>Explore</h4></li>
                  <Li><a href="#">Home</a></Li> 
                  <Li><a href="#">Reservation</a></Li> 
                  <Li><a href="#">Offers</a></Li> 
                  <Li><a href="#">Counsolation</a></Li> 
             </ul>
            </div>
            
          <div class="column">
             <ul >
                  <li><h4>Social</h4></li>
                  <Li><a href="#">YouTube</a></Li> 
                  <Li><a href="#">Instagram</a></Li> 
                  <Li><a href="#">FaceBook</a></Li> 
             </ul>
            </div>
            
          <div class="column">
             <ul>
                  <li><h4>Help</h4></li>
                  <Li><a href="#">Contact US</a></Li> 
                  <Li><a href="#">About</a></Li> 
                   
             </ul>
            </div>
       </div>
       </footer>
</body>
</html>









