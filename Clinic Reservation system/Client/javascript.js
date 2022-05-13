const characters ='ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';


function generateString(length) 
{

    document.getElementById("button1").onclick = function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
       
     
        var code1=document.getElementById("code1");
        code1.setAttribute("value",result);
    }
  
       
    document.getElementById("button2").onclick=function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
    
        var code2= document.getElementById("code2");
        code2.setAttribute("value",result);
    }
    
        
    document.getElementById("button3").onclick = function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
    
        var code3= document.getElementById("code3");
        code3.setAttribute("value",result);
    }
  
       
    document.getElementById("button4").onclick=function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
   
        var code4=document.getElementById("code4");
        code4.setAttribute("value",result);
    }
    
        
    document.getElementById("button5").onclick = function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
   
        var code5= document.getElementById("code5");
        code5.setAttribute("value",result);
    }
  
       
    document.getElementById("button6").onclick=function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
   
        var code6= document.getElementById("code6");
        code6.setAttribute("value",result);
    }
        
    document.getElementById("button7").onclick = function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
    
        var code7= document.getElementById("code7");
        code7.setAttribute("value",result);
    }
  
       
    document.getElementById("button8").onclick=function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        
        var code8= document.getElementById("code8");
        code8.setAttribute("value",result);
    }
        
    document.getElementById("button9").onclick = function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
     
        var code9= document.getElementById("code9");
        code9.setAttribute("value",result);
    }
  
       
    document.getElementById("button10").onclick=function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        
        var code10=document.getElementById("code10");
        code10.setAttribute("value",result);
    }
        
    document.getElementById("button11").onclick = function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        
        var code11= document.getElementById("code11");
        code11.setAttribute("value",result);
    }
  
       
    document.getElementById("button12").onclick=function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        
        var code12= document.getElementById("code12");
        code12.setAttribute("value",result);
    }
        
    document.getElementById("button13").onclick = function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
      
        var code13=  document.getElementById("code13");
        code13.setAttribute("value",result);
    }
  
       
    document.getElementById("button14").onclick=function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
       
        var code14=document.getElementById("code14");
        code14.setAttribute("value",result);
    }
        
    document.getElementById("button15").onclick = function()
    {
        
        let result = ' ';
        const charactersLength = characters.length;
    
        for ( let i = 0; i < length; i++ ) 
        {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        
        var code15=document.getElementById("code15");
        code15.setAttribute("value",result);
    }
  
       

 
}
    
 
    
function myFunction() {
    
     document.getElementById("img1").onclick = function()
     {
         
        var copyText1 = document.getElementById("code1");
        copyText1.select();
        copyText1.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText1.value);

        alert("Copied the code: " + copyText1.value);
     }  
     
     document.getElementById("img2").onclick = function()
     {
         
        var copyText2 = document.getElementById("code2");
        copyText2.select();
        copyText2.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText2.value);

        alert("Copied the code: " + copyText2.value);
     }
          
    document.getElementById("img3").onclick = function()
    {
         
        var copyText3 = document.getElementById("code3");
        copyText3.select();
        copyText3.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText3.value);

        alert("Copied the code: " + copyText3.value);
     }
        
     document.getElementById("img4").onclick = function()
     {
         
        var copyText4 = document.getElementById("code4");
        copyText4.select();
        copyText4.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText4.value);

        alert("Copied the code: " + copyText4.value);
     }  
     
     document.getElementById("img5").onclick = function()
     {
         
        var copyText5 = document.getElementById("code5");
        copyText5.select();
        copyText5.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText5.value);

        alert("Copied the code: " + copyText5.value);
     }
          
    document.getElementById("img6").onclick = function()
    {
         
        var copyText1 = document.getElementById("code6");
        copyText6.select();
        copyText6.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText6.value);

        alert("Copied the code: " + copyText6.value);
     }
        
     document.getElementById("img7").onclick = function()
     {
         
        var copyText7 = document.getElementById("code7");
        copyText7.select();
        copyText7.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText7.value);

        alert("Copied the code: " + copyText7.value);
     }  
     
     document.getElementById("img8").onclick = function()
     {
         
        var copyText8 = document.getElementById("code8");
        copyText8.select();
        copyText8.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText8.value);

        alert("Copied the code: " + copyText8.value);
     }
          
    document.getElementById("img9").onclick = function()
    {
         
        var copyText9 = document.getElementById("code9");
        copyText9.select();
        copyText9.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText9.value);

        alert("Copied the code: " + copyText9.value);
     }
        
     document.getElementById("img10").onclick = function()
     {
         
        var copyText10 = document.getElementById("code10");
        copyText10.select();
        copyText10.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText10.value);

        alert("Copied the code: " + copyText10.value);
     }  
     
     document.getElementById("img11").onclick = function()
     {
         
        var copyText11 = document.getElementById("code11");
        copyText11.select();
        copyText11.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText11.value);

        alert("Copied the code: " + copyText11.value);
     }
          
    document.getElementById("img12").onclick = function()
    {
         
        var copyText12 = document.getElementById("code12");
        copyText12.select();
        copyText12.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText12.value);

        alert("Copied the code: " + copyText12.value);
     }
        
     document.getElementById("img13").onclick = function()
     {
         
        var copyText13 = document.getElementById("code13");
        copyText13.select();
        copyText13.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText13.value);

        alert("Copied the code: " + copyText13.value);
     }  
     
     document.getElementById("img14").onclick = function()
     {
         
        var copyText14 = document.getElementById("code14");
        copyText14.select();
        copyText14.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText14.value);

        alert("Copied the code: " + copyText14.value);
     }
     
    document.getElementById("img15").onclick = function()
    {
         
        var copyText15 = document.getElementById("code15");
        copyText15.select();
        copyText15.setSelectionRange(0, 99999); 
        navigator.clipboard.writeText(copyText15.value);

        alert("Copied the code: " + copyText15.value);
  
     }
    

}

function validateForm() {
 var x = document.forms["forms"]["name"].value;
    
if (x == "") {
    alert("name must be filled");
 return false;
 }
    
 x = document.forms["forms"]["age"].value;
if(x=""){
     alert("Age must be filled");
    return false;
}else if(!x.value>=18){
    alert("must be 18 or above");
    return false;
}
    
 x = document.forms["forms"]["pnum"].value;
 if (x == "") {
 alert("Phone number must be filled out");
 return false;
 }else if (x.length !="11") {
 alert("Must be 11 numbers included");
     return false;
 }
    
x = document.forms["forms"]["promocode"].value;
 if (x == "") {
 alert("Promocode must be filled");
 return false;
 }

}

function name(){
document.getElementById("name1").onclick=function()
{
    const top1=document.getElementById("top1");
    
    while (top1.hasChildNodes()) {
    top1.removeChild(top1.firstChild);
}
    
    var para = document.createElement("p");
    para.setAttribute("id","para1");
    var textNode = document.createTextNode("DR.Sherif");
    para.appendChild(textNode);
var img=document.createElement("img");
    para.style.marginLeft="12px";
    img.src="Images/Dr5.png";
  img.style.float="left";
  img.style.width="40px";
  img.style.height= "40px";
  img.style.marginRight= "12px";
  img.style.borderRadius= "50%";
     top1.appendChild(img);
    top1.appendChild(para);
     
}
document.getElementById("name2").onclick=function()
{
        const top1=document.getElementById("top1");
    
    while (top1.hasChildNodes()) {
    top1.removeChild(top1.firstChild);
}
    var para = document.createElement("p");
     para.setAttribute("id","para2");
    var textNode = document.createTextNode("DR.Abeer");
    para.appendChild(textNode);
var img=document.createElement("img");
    para.style.marginLeft="12px";
    img.src="images/dr1.png";
  img.style.float="left";
  img.style.width="40px";
  img.style.height= "40px";
  img.style.marginRight= "12px";
  img.style.borderRadius= "50%";
     top1.appendChild(img);
    top1.appendChild(para);
}
document.getElementById("name3").onclick=function()
{
         const top1=document.getElementById("top1");
    
    while (top1.hasChildNodes()) {
    top1.removeChild(top1.firstChild);
}
    var para = document.createElement("p");
     para.setAttribute("id","para3");
    var textNode = document.createTextNode("DR.Mohamed");
    para.appendChild(textNode);
   var img=document.createElement("img");
    para.style.marginLeft="12px";
    img.src="images/dr3.jpg";
  img.style.float="left";
  img.style.width="40px";
  img.style.height= "40px";
  img.style.marginRight= "12px";
  img.style.borderRadius= "50%";
     top1.appendChild(img);
    top1.appendChild(para);
       
}
document.getElementById("name4").onclick=function()
{
         const top1=document.getElementById("top1");
    
    while (top1.hasChildNodes()) {
    top1.removeChild(top1.firstChild);
}
    var para = document.createElement("p");
     para.setAttribute("id","para4");
    var textNode = document.createTextNode("DR.Habiba");
    para.appendChild(textNode);
   var img=document.createElement("img");
    para.style.marginLeft="12px";
    img.src="images/dr4.png";
  img.style.float="left";
  img.style.width="40px";
  img.style.height= "40px";
  img.style.marginRight= "12px";
  img.style.borderRadius= "50%";
     top1.appendChild(img);
    top1.appendChild(para);
       
}
       
document.getElementById("name5").onclick=function()
{
        const top1=document.getElementById("top1");
    
    while (top1.hasChildNodes()) {
    top1.removeChild(top1.firstChild);
}
    var para = document.createElement("p");
     para.setAttribute("id","para5");
    var textNode = document.createTextNode("DR.Adel");
    para.appendChild(textNode);
    var img=document.createElement("img");
    para.style.marginLeft="12px";
    img.src="images/dr2.webp";
  img.style.float="left";
  img.style.width="40px";
  img.style.height= "40px";
  img.style.marginRight= "12px";
  img.style.borderRadius= "50%";
     top1.appendChild(img);
    top1.appendChild(para);
       
}
document.getElementById("name6").onclick=function()
{
    const top1=document.getElementById("top1");
    
    while (top1.hasChildNodes()) 
    {
    top1.removeChild(top1.firstChild);
    }
    var para = document.createElement("p");
     para.setAttribute("id","para1");
    var textNode = document.createTextNode("DR.Yousef");
    para.appendChild(textNode);
    var img=document.createElement("img");
    para.style.marginLeft="12px";
    img.src="images/dr6.jpg";
    img.style.float="left";
    img.style.width="40px";
    img.style.height= "40px";
    img.style.marginRight= "12px";
    img.style.borderRadius= "50%";
    top1.appendChild(img);
    top1.appendChild(para);
  
       
}
}



function my(){
            $(".openBtn").click(function(){
        document.getElementById("popup").style.visibility="visible";
    })
 

    $(".closeBtn").click(function(){

        document.getElementById("popup").style.visibility="hidden";
    })

    $(".popup").click(function () {
        document.getElementById("popup").style.visibility="hidden";
    }).children().click(function () {
      return false;
    })
        $(".openBtn_1").click(function(){
        document.getElementById("popup_1").style.visibility="visible";
    })
 

    $(".closeBtn_1").click(function(){

        document.getElementById("popup_1").style.visibility="hidden";
    })

    $(".popup_1").click(function () {
        document.getElementById("popup_1").style.visibility="hidden";
    }).children().click(function () {
      return false;
    })
    
            $(".openBtn_2").click(function(){
        document.getElementById("popup_2").style.visibility="visible";
    })
 

    $(".closeBtn_2").click(function(){

        document.getElementById("popup_2").style.visibility="hidden";
    })
 

    $(".popup_2").click(function () {
        document.getElementById("popup_2").style.visibility="hidden";
    }).children().click(function () {
      return false;
    })
}
