# Fortune Entertainment City

### 作者:[nicharleys](https://github.com/nicharleys) 建置


<br><br><br>

<div align="center">
   <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Gif/1.gif"  width="400" height="228"/>
   <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Gif/2.gif"  width="400" height="228"/> <br>
    <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Gif/3.gif"  width="400" height="228"  />
   <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Gif/4.gif"  width="400" height="228" />
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
   <h3 styles={font-weight:bold;}>(1) NodeJS安裝</h3>
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
   <h3 styles={font-weight:bold;}>(2) NodeJS插件安裝</h3>
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
   <h3 styles={font-weight:bold;}>(9) Unity3D設定</h3>
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

<span id="head1">  <h2> 詳細說明 </h2> </span>
<div>
<strong font-size:13px;>
首先說明基礎系統的設置，系統在場景的切換設定為場景狀態，每個狀態有各自的ISceneState類管理，並透過SceneStateContext連結關係，每個場景狀態只執行各自的任務，因此不同的場景所執行的程式不會互相關聯，確保每項任務明確執行。
<br/>
<br/>
在簡單的場景，像是過場或預先載入，可以在該狀態類直接設定要執行的內容，但在內容較多需要管理的情況下建議設置一個ISystemFunction類進行管理，而該類別建立後可以參考範例修改成單例、外觀、仲介者合一的類別，並在內容設置IUserInterface、ISystem，在設置完成後，可以將ISystemFunction類的方法置入ISceneState類內，由此統一管理與執行。
<br/>
<br/>
每個場景的切換在SceneStateContext內會自動調用Addressable的場景載入，但釋放前一個場景需要在ISceneState的StateEnd內設定。
<br/>
<br/>

<div align="center">
   <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Pic/1.jpg"  width="800" height="456" /> <br>
</div>

<br/>
<br/>

</strong>
<strong font-size:13px;>
再來是資料處理的部分，系統透過IUserInterface設定畫面，並由ISystem處理UI事件，同時透過ISystem傳接資料至DataCenter內對應的資料內容。
<br/>
<br/>
資料的內容分為遠端跟本地兩種，傳輸的方式是由DataRequest類取得或儲存，本地的資料是用Application.persistentDataPath的方式存成Json檔，因此通常有固定的儲存位置，遠端則直接依照網址執行UnityWebRequest，並用Post的方式請求資料，網址位置需要在DataCenter類與Memento類設定。
<br/>
<br/>
DataCenter的資料內容通過新增類別存放，在於管理時較為方便，並且內容存取只能透過該類別方法，資料的公開屬性則是回傳私有欄位，確保資料不被更改。
<br/>
<br/>
附帶一提的是網路狀態測試的方法設置於DataCenter內，當有遠端載入AB包或是遠端請求資料的操作應當調用NetworkTest方法，並在該類加入網路異常事件至NetworkFailedHandler。
<br/>
<br/>
<div align="center">
<img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Pic/2.jpg"  width="800" height="456" /> <br>
<img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Pic/3.jpg"  width="800" height="140" /> <br>
<img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Pic/4.jpg"  width="400" height="228" /> 
   <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Pic/5.jpg"  width="400" height="228" /> <br>
</div>
</strong>

<br/>
<br/>

<strong font-size:13px;>
本地的資料儲存用於自動登入帳號，登入方式分為帳號登入跟遊客登入，並在使用者初次登入時儲存登入類型與帳號、密碼，而在大廳的設定面板可以點選帳號設定，並選擇切換帳號或登出帳號，切換帳號是將本地儲存的登入類型檔案刪掉，而登出帳號則是刪除本地儲存的帳號、密碼，因此對於本地登入的用戶在登出帳號時應給予警示。
<br/>
<br/>
在使用者透過遠端載入其他遊戲的AB包時，系統也會儲存載入的遊戲名稱，以此判斷使用者是否為初次載入，並判斷遊戲的載入選項是更新或下載，同時也用於再次進入系統時判斷能否卸載遊戲。
<br/>
<br/>
<div align="center">
<img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Pic/6.jpg"  width="400" height="70" />
<img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Pic/7.jpg"  width="400" height="70" /> <br>
<img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Pic/8.jpg"  width="400" height="180" />
   <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Pic/9.jpg"  width="400" height="180" /> <br>
      <img src="https://github.com/nicharleys/FortuneEntertainmentCity/blob/master/Pictures/Pic/10.jpg"  width="800" height="250" /> <br>
</div>
</strong>

</div>

<br>
<br>
