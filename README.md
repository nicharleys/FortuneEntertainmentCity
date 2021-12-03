# Fortune Entertainment City
 
### 作者:[nicharleys](https://github.com/nicharleys) 建置


<br><br><br>

<div align="center">
   <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/1.gif"  width="400" height="228" "  />
   <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/2.gif"  width="400" height="228" " /> <br>    
    <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/3.gif"  width="400" height="228" "  />
   <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/4.gif"  width="400" height="228" " /> 
</div>

<br><br><br>
# I、介紹

<div>
   <h3 styles={font-weight:bold;}>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp        這是一個使用單例、外觀、仲介者、狀態模式所製作的基礎系統，並以簡易的NodeJS程式測試資料的傳接過程。其中使用到Unity的Addressable來達到熱更新效果，同時在UGUI的部分設計靜態與動態Canvas分離，以此減少UGUI的Rebuild過程與性能消耗，並使用Atlas圖集減少DrawCall產生，讓UI介面能以高效的方式呈現給使用者。資料的部分提供UI類、System類與資料中心達到MVP模式的效果，並在網路操作前有網路狀態測試。基礎系統的部分只處理登入與載入，內容依照需求可再加入其他遊戲，藉此方式設計成遊戲大廳並提供其他遊戲的載入與啟動。
</<h3> 
</div> 


<br>
<div align="center">
<table border="1">
    <tr>
        <td>
            <div>
            <h3><b>優點:</b><br></h3>
            <b>&nbsp; 1.可以隨時進行熱更新。 </b><br>
            <b>&nbsp; 2.資料、UI、System管理方便。 </b><br>
            <b>&nbsp; 3.狀態執行內容明確。 </b><br>
            <b>&nbsp; 4.網路異常可再自動重新操作。 </b><br>
            <b>&nbsp; 5.功能新增已有範例遵循。 </b>
           </div>
        </td>
        <td>
            <div>
            <h3><b>缺點:</b><br></h3><br>
            <b>&nbsp; 1.比較適用於大型系統。 </b><br>
            <b>&nbsp; 2.內容新增需用程式編寫。 </b><br>
            <b>&nbsp; 3.系統需要Server支援。 </b>
            <br><br><br>
           </div>
        </td>
    </tr>
</table>
<br>
<br>
 </div>
 
 
# II、啟動流程

<div>    
<table border="1">
    <tr>
        <td>
            <div>
            <b>1.</b><br>
            <strong font-size:13px;>安裝並啟動NodeJS。</strong>
           </div>
        </td>
    </tr>
</table>
</div> 

[NodeJS安裝](#head1) 、 [NodeJS插件安裝](#head2)

<div>    
<table border="1">
    <tr>
        <td>
            <div>
            <b>2.</b><br>
            <strong font-size:13px;>設置Unity3D設定。</strong>
           </div>
        </td>
    </tr>
</table>
</div> 

[Unity3D設定](#head3)

<br>
<br>

# III、環境建置

<div  id = 'head1'>
   <h3 styles={font-weight:bold;}>(1) NodeJS安裝</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>透過網址安裝NodeJS。</b>
           </div>
        </td>
    </tr>
</table>

[NodeJS下載網址](#download1)

<table border="1">
    <tr>
        <td>
            <div>
            <b> 2.</b><br>
            <b>設置環境變數：</b><br>
            <b>本機-->右鍵內容-->進階設定-->環境變數-->系統變數(path)-->C:\Program Files\nodejs\</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>

<div id = 'head2'>
   <h3 styles={font-weight:bold;}>(2) NodeJS插件安裝</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>在NodeJsServer檔案中找到以下檔案：</b><br>
            <b>package-lock.json。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 2.</b><br>
            <b>cmd到放置檔案的資料位置。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 3.</b><br>
            <b>輸入npm install 。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 4.</b><br>
            <b>輸入node Server.js啟動簡易測試程式。</b>
           </div>
        </td>
    </tr>
</table>

<table border="1">
    <tr>
        <td>
            <div>
            <b> 5.</b><br>
            <b>設置Unity3D設定</b>
           </div>
        </td>
    </tr>
</table>

<br>
<br>                             

<div  id = 'head3'>
   <h3 styles={font-weight:bold;}>(9) Unity3D設定</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>在Unity3D的DataScripts資料夾找到DataCenter類別。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 2.</b><br>
            <b>設定NodeJS Server的網址至_postAddress欄位。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 3.</b><br>
            <b>設定要執行Ping測試的地址至_pingAddress欄位。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 4.</b><br>
            <b>自行輸出至所要平台。</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>    

# IV、文件說明

<span id="head1">  <h2> 資料傳輸 </h2> </span>

<div> 
<strong font-size:13px;>
本系統使用NodeJS作為模擬伺服器資料回傳，因此需要安裝NodeJS並啟動Server.js才能正常使用系統。
<br/>
若不想使用模擬伺服器，可自行對照模擬伺服器內的app.post名稱，並在該方法回傳資料庫內容，而Unity3D的資料接收在DataScripts資料夾內的DataCenter類，您需要修改_postAddress欄位內容，並將該內容設置成Server網址，網址後段內容可在DataCenter內設置的UserInfoMemento進行修改。
</strong>
</div> 
<br/>
<div> 
<strong font-size:13px;>
NodeJS安裝版本為8.12.0，安裝作業系統為Windows 10，若建置過程失敗或介面問題可以參考此版本。
</strong>
</div>
<br/>

<div id = 'download1'> 
<strong font-size:13px;>
NodeJS的下載網址：

https://nodejs.org/download/release/v8.12.0/

</strong>
</div>
<br/>

<br>
<br>
