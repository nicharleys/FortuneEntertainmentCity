# Fortune Entertainment City
 
### 作者:[nicharleys](https://github.com/nicharleys) 建置

<img src="https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https://github.com/nicharleys/GameChargingSystem-Ethereum-SmartContract-Unity3D-NodeJS_1" alt="Hits" data-canonical-src="https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https://github.com/nicharleys/GameChargingSystem-Ethereum-SmartContract-Unity3D-NodeJS" style="max-width:100%;"></a> 


<br><br><br>

<div align="center">
   <img src="https://github.com/nicharleys/GameChargingSystem-Ethereum-SmartContract-Unity3D-NodeJS/blob/main/Gif/1.gif"  width="400" height="228" "  />
   <img src="https://github.com/nicharleys/GameChargingSystem-Ethereum-SmartContract-Unity3D-NodeJS/blob/main/Gif/2.gif"  width="400" height="228" " /> <br>    
    <img src="https://github.com/nicharleys/GameChargingSystem-Ethereum-SmartContract-Unity3D-NodeJS/blob/main/Gif/3.gif"  width="400" height="228" "  />
   <img src="https://github.com/nicharleys/GameChargingSystem-Ethereum-SmartContract-Unity3D-NodeJS/blob/main/Gif/4.gif"  width="400" height="228" " /> 
</div>

<br><br><br>
# I、介紹

<div>
   <h3 styles={font-weight:bold;}>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp        這是一個使用乙太坊的智能合約功能結合Unity3D遊戲來實現的交易系統，串接方式是由NodeJS所寫成Dapp做為資料的傳接過程，並傳送至Photon Cloud伺服器以提供多人參與交易，藉由Unity3D的輸出結果可以決定使用的平台，讓使用者可以在不同的環境下使用智能合約功能，並以高效率的交易速度來達成虛擬貨幣以及合約代幣的交易，本系統以串接方式為例。
</<h3> 
</div> 


<br>
<div align="center">
<table border="1">
    <tr>
        <td>
            <div>
            <h3><b>優點:</b><br></h3>
            <b>&nbsp; 1.可以自由更換環境。 </b><br>
            <b>&nbsp; 2.不影響交易速度下運行乙太坊。 </b><br>
            <b>&nbsp; 3.保有高度交易安全性。 </b><br>
            <b>&nbsp; 4.共用此系統可共通交易貨幣。 </b><br>
            <b>&nbsp; 5.多人連線可自行選擇交易對象。 </b>
           </div>
        </td>
        <td>
            <div>
            <h3><b>缺點:</b><br></h3><br>
            <b>&nbsp; 1.必須要有網路。 </b><br>
            <b>&nbsp; 2.必須要有主機作為伺服器。 </b><br>
            <b>&nbsp; 3.交易代幣需要購買或是挖礦獲取。 </b>
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
            <strong font-size:13px;>安裝並啟動私有鏈。</strong>
           </div>
        </td>
    </tr>
</table>
</div>

[Geth安裝](#head1) 、 [Puppeth設定](#head2) 、 [私有鏈節點啟動](#head3)

<div>    
<table border="1">
    <tr>
        <td>
            <div>
            <b>2.</b><br>
            <strong font-size:13px;>透過Remix Solidity發佈智能合約。</strong>
           </div>
        </td>
    </tr>
</table>
</div>

[發佈智能合約](#head4)

<div>    
<table border="1">
    <tr>
        <td>
            <div>
            <b>3.</b><br>
            <strong font-size:13px;>更換Dapp內的智能合約內容。</strong>
           </div>
        </td>
    </tr>
</table>
</div> 

[更換Dapp設置](#head5)

<div>    
<table border="1">
    <tr>
        <td>
            <div>
            <b>4.</b><br>
            <strong font-size:13px;>設置Photon Cloud伺服器。</strong>
           </div>
        </td>
    </tr>
</table>
</div> 

[Photon Cloud設定](#head6)

<div>    
<table border="1">
    <tr>
        <td>
            <div>
            <b>5.</b><br>
            <strong font-size:13px;>安裝並啟動NodeJS。</strong>
           </div>
        </td>
    </tr>
</table>
</div> 

[NodeJS安裝](#head7) 、 [NodeJS插件安裝](#head8)

<div>    
<table border="1">
    <tr>
        <td>
            <div>
            <b>6.</b><br>
            <strong font-size:13px;>設置Unity3D設定。</strong>
           </div>
        </td>
    </tr>
</table>
</div> 

[Unity3D設定](#head9)

<br>
<br>

# III、環境建置

<div id = 'head1'>
   <h3 styles={font-weight:bold;}>(1) Geth安裝</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>透過 Go Ethereum網址安裝 Geth。</b>
           </div>
        </td>
    </tr>
</table>

[Go Ethereum下載網址](#download1)

<table border="1">
    <tr>
        <td>
            <div>
            <b> 2.</b><br>
            <b>Geth 安裝過程要勾選 Development tools。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 3.</b><br>
            <b>建立一個新帳號 geth --datadir “自訂資料夾名稱” account new。</b><br>
            <b>範例的資料夾名稱： Ethtest_ERC20。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 4.</b><br>
            <b>使用 Geth工具 puppeth 設定創世區塊。</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>

<div  id = 'head2'>
   <h3 styles={font-weight:bold;}>(2) Puppeth設定</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>開啟Go Ethereum的工具 puppeth 設定創世區塊。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 2.</b><br>
            <b>輸入自訂的網路名稱。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 3.</b><br>
            <b>輸入2，設定創世區塊的內容。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 4.</b><br>
            <b>自行選擇使用PoA或PoW共識機制。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 5.</b><br>
            <b>設定區塊產出時間，直接空白輸入則為預設15秒。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 6.</b><br>
            <b>設定挖礦帳號，輸入在Geth建立的帳號，若不再新增則直接空白輸入。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 7.</b><br>
            <b>給予帳號乙太幣，若不需要則直接空白輸入。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 8.</b><br>
            <b>設定Chain ID，請避開常用ID，範例使用8888。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 9.</b><br>
            <b>輸入2，管理現有創世區塊。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 10.</b><br>
            <b>輸入2，導出創世區塊的配置。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 11.</b><br>
            <b>輸入檔案導出位置，若空白輸入則在C槽。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 12.</b><br>
            <b>導出genesis.json檔案。</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>


<div id = 'head3'>
   <h3 styles={font-weight:bold;}>(3) 私有鏈節點啟動</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>放置genesis.json到要設置的資料夾，建議放在Geth帳號的上一層。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 2.</b><br>
            <b>cmd到要設置的資料夾。</b><br>
            <b>範例的資料夾： Geth。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 3.</b><br>
            <b>輸入geth --datadir “資料夾名稱” init genesis.json，啟動創世區塊。</b><br>
            <b>範例的資料夾名稱： Ethtest_ERC20。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 4.</b><br>
            <b>cmd到最外層的geth資料夾。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 5.</b><br>
            <b>輸入啟動指令啟動私有鏈。</b>
           </div>
        </td>
    </tr>
</table>

[Geth啟動指令](#code1)

<br>
<br>


<div id = 'head4'>
   <h3 styles={font-weight:bold;}>(4) 發佈智能合約</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>啟動私有鏈。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 2.</b><br>
            <b>開啟Remix Solidity的網站。</b>
           </div>
        </td>
    </tr>
</table>

[Remix Solidity舊網址](#download2)

<table border="1">
    <tr>
        <td>
            <div>
            <b> 3.</b><br>
            <b>選擇編輯器版本，範例為0.4.24+commit .e67f0147。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 4.</b><br>
            <b>複製範例檔案中的 " 智能合約程式碼 " 內容。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 5.</b><br>
            <b>新增空白程式，將複製內容貼至Remix編輯器內，並取名ERC20_token。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 6.</b><br>
            <b>複製範例檔案中的 " 智能合約程式碼_函式 " 內容。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 7.</b><br>
            <b>新增空白程式，將複製內容貼至Remix編輯器內，並取名ERC20_interface。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 8.</b><br>
            <b>編輯器選項選擇發佈Run。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 9.</b><br>
            <b>環境Environment選擇Web3 Provider，並輸入IP位置:私有鏈Port號。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 10.</b><br>
            <b>創建並選擇發佈帳號。</b>
           </div>
        </td>
    </tr>
</table>

[創建新帳號](#code3)

<table border="1">
    <tr>
        <td>
            <div>
            <b> 11.</b><br>
            <b>程式碼發佈選擇ERC20_token。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 12.</b><br>
            <b>Deploy內輸入以下資料：</b><br>
            <b>總代幣量, 代幣1價值, 代幣2價值, 代幣3價值, "代幣名稱", "說明文字", "發佈帳號"</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 13.</b><br>
            <b>解鎖帳號</b>
           </div>
        </td>
    </tr>
</table>

[解鎖帳號](#code5)

<table border="1">
    <tr>
        <td>
            <div>
            <b> 14.</b><br>
            <b>在有足夠的乙太幣情況下，按下Deploy發佈智能合約，若沒有請執行挖礦。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 15.</b><br>
            <b>執行挖礦來打包合約創建的交易。</b>
           </div>
        </td>
    </tr>
</table>

[指定挖礦帳號](#code4) 、 [執行挖礦](#code6)

<table border="1">
    <tr>
        <td>
            <div>
            <b> 16.</b><br>
            <b>紀錄發佈後產出的智能合約地址。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 17.</b><br>
            <b>編輯器選項選擇編輯Compile。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 18.</b><br>
            <b>點選ABI或Details的ABI複製智能合約ABI資料。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 19.</b><br>
            <b>紀錄智能合約ABI資料。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 20.</b><br>
            <b>更換合約相關資料。</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>

<div id = 'head5'>
   <h3 styles={font-weight:bold;}>(5) 更換Dapp設置</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>複製範例檔案的NodeJS文件至自訂專案位置。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 2.</b><br>
            <b>修改Dapp文件的contract文件內的contract.js檔。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 3.</b><br>
            <b>將智能合約ABI覆蓋至ABI:[ ]內。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 4.</b><br>
            <b>將智能合約地址覆蓋至底部的address:” ”內。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 5.</b><br>
            <b>設置與Dapp功能對應的Photon Cloud設定。</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>

<div id = 'head6'>
   <h3 styles={font-weight:bold;}>(6) Photon Cloud設定</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>申請帳號。</b>
           </div>
        </td>
    </tr>
</table>

[Photon Cloud官方網址](#download3)

<table border="1">
    <tr>
        <td>
            <div>
            <b> 2.</b><br>
            <b>建立應用程式。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 3.</b><br>
            <b>Photon Type類型為Photon PUN。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 4.</b><br>
            <b>名稱範例為Game。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 5.</b><br>
            <b>網址為本機IP位置。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 6.</b><br>
            <b>建立Webhooks功能，版本為1.2。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 7.</b><br>
            <b>輸入8筆Key，Key值：2 ~ 9，Value值：IP:3000/。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 8.</b><br>
            <b>輸入1筆Key，Key值：BaseUrl，Value值：IP:3000。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 9.</b><br>
            <b>輸入1筆Key，Key值：ListenEvent，Value值：IP:3000/ ListenEvent。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 10.</b><br>
            <b>輸入1筆Key，Key值：Transform，Value值：IP:3000/ Transform。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 11.</b><br>
            <b>安裝NodeJS相關工具。</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>

<div  id = 'head7'>
   <h3 styles={font-weight:bold;}>(7) NodeJS安裝</<h3> 
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

[NodeJS下載網址](#download4)

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

<div id = 'head8'>
   <h3 styles={font-weight:bold;}>(8) NodeJS插件安裝</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>在NodeJS範例檔案中找到以下檔案：</b><br>
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
            <b>在NodeJS範例檔案內的Dapp資料夾中找到以下檔案：</b><br>
            <b>package.json、package-lock.json。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 5.</b><br>
            <b>cmd到放置檔案的資料位置。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 6.</b><br>
            <b>輸入npm install 。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 7.</b><br>
            <b>啟動NodeJS的Dapp檔。</b>
           </div>
        </td>
    </tr>
</table>

[NodeJS啟動指令](#code2)

<table border="1">
    <tr>
        <td>
            <div>
            <b> 8.</b><br>
            <b>設置Unity3D設定</b>
           </div>
        </td>
    </tr>
</table>

<br>
<br>                             

<div  id = 'head9'>
   <h3 styles={font-weight:bold;}>(9) Unity3D設定</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 1.</b><br>
            <b>在Photon Cloud的PUN設定找到APP ID。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 2.</b><br>
            <b>在Unity3D的Resources資料夾找到PhotonServerSettings檔案。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b> 3.</b><br>
            <b>設定APP ID為PUN設定的APP ID。</b>
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

<span id="head1">  <h2> 智能合約設計 </h2> </span>

<div> 
<strong font-size:13px;>
本系統使用Go Ethereum的Geth作為私有鏈伺服器，以此做為資料存取的儲存空間，因此在執行系統前需要建置私有鏈環境，建置內容包含選擇工作證明類型、產出區塊時間、Chain ID設定，過程需要使用puppeth來建立創世區塊，藉此才能提供Geth來啟動私有鏈。
</strong>
</div> 
<br/>
<div> 
<strong font-size:13px;>
若不想設定Puppeth，可以在範例的Geth資料夾內找到創世區塊配置genesis.json。
</strong>
</div>
<br/>
<div> 
<strong font-size:13px;>
Go Ethereum安裝版本為1.8.16，NodeJS安裝版本為8.12.0，安裝作業系統為Windows 10，若建置過程失敗或介面問題可以參考此版本。
</strong>
</div>
<br/>
<div id = 'download1'> 
<strong font-size:13px;>
Go Ethereum的下載網址：

https://geth.ethereum.org/downloads/

</strong>
</div>
<br/>
<div id = 'download2'> 
<strong font-size:13px;>
Remix Solidity的舊網址：

https://remix.ethereum.org/#appVersion=0.7.7&optimize=false&version=soljson-v0.5.1+commit.c8a2cb62.js

</strong>
</div>
<br/>
<div id = 'download3'> 
<strong font-size:13px;>
Photon Cloud官方網址：

https://www.photonengine.com/zh-TW/photon

</strong>
</div>
<br/>
<div id = 'download4'> 
<strong font-size:13px;>
NodeJS的下載網址：

https://nodejs.org/download/release/v8.12.0/

</strong>
</div>
<br/>

<br/>


<div id = 'code1'>
   <h3 styles={font-weight:bold;}>(1) Geth指令</<h3> 
</div>

<table border="1">
    <tr>
        <td>
            <div>
            <b>1.</b><br>
            <b>啟動指令，請注意networkid需與創世區塊的Chain ID一致。</b><br>
            <b>範例指令：geth --rpc --rpcport 6345 --rpcaddr 0.0.0.0 --datadir ./Ethtest_ERC20 --rpccorsdomain="*" --rpcapi="eth,net,web3,personal" --port 30303 --networkid 8888 --nodiscover console。</b>
           </div>
        </td>
    </tr>
</table>  
<table border="1">
    <tr>
        <td>
            <div id = 'code6'>
            <b>2.</b><br>
            <b>執行、暫停挖礦需要輸入指令，指令如下所示：</b><br>
            <b>指令：miner.start(執行緒數)、miner.stop()</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>3.</b><br>
            <b>關閉私有鏈需要輸入指令，若直接關閉可能會造成私有鏈回朔或是重製，指令如下所示：</b><br>
            <b>指令：exit</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>

<div>
   <h3 styles={font-weight:bold;}>(2) 私有鏈指令</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div id = 'code5'>
            <b>1.</b><br>
            <b>若要解鎖私有鏈主帳號，則輸入指令解鎖，指令如下所示：</b><br>
            <b>指令：personal.unlockAccount(eth.accounts[0])</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div id = 'code3'>
            <b>2.</b><br>
            <b>若要新增私有鏈帳號，則輸入指令新增，指令如下所示：</b><br/>
            <b>指令：personal.newAccount()</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div id = 'code4'>
            <b>3.</b><br>
            <b>若要更改私有鏈挖礦的帳號，則輸入指令更改，指令如下所示：</b><br>
            <b>指令：miner.setEtherbase(帳號)</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>

<div id = 'code2'>
   <h3 styles={font-weight:bold;}>(3) NodeJS指令</<h3> 
</div>

<table border="1">
    <tr>
        <td>
            <div>
            <b>1.</b><br>
            <b>cmd輸入指令啟動NodeJS，開啟位置與指令如下所示：</b><br>
            <b>開啟位置： NodeJS\Dapp</b><br>
            <b>指令： node index.js</b>
           </div>
        </td>
    </tr>
</table>   
<br>
<br>

<div>
   <h3 styles={font-weight:bold;}>(4) NodeJS頁面說明</<h3> 
</div>
<div> 
<strong font-size:13px;>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp在server.js的內容可以找到app.post開頭的函式，各函式名稱代表連接網址，若有更動則需要對應更改Detail.js內的設置網址，因此建議不作更改，各項說明如下所示：</strong>
</div>
<br/>
<table border="1">
    <tr>
        <td>
            <div>
            <b>1.</b><br>
            <b>ListenEvent</b><br/>
            <b>監聽區塊編號，區塊編號更新就自動發送查詢功能，以此達到自動更新的效果。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>2.</b><br>
            <b>Transform</b><br/>
            <b>執行合約功能，根據不同的傳送狀態來執行對應的私有鏈指令。</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>

<div>
   <h3 styles={font-weight:bold;}>(5) NodeJS合約執行說明</<h3> 
</div>
<table border="1">
    <tr>
        <td>
            <div>
            <b>1.</b><br>
            <b>Allowance</b><br/>
            <b>信用查詢，查詢給予他人或被給予的信用額度。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>2.</b><br>
            <b>BalanceOf</b><br/>
            <b>代幣查詢，查詢指定帳號內的剩餘代幣。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>3.</b><br>
            <b>LookExchange_Self</b><br/>
            <b>交換查詢，查詢自方與他方的交易內容。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>4.</b><br>
            <b>LookExchange_Other</b><br/>
            <b>交換查詢，查詢他方與自方的交易內容。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>5.</b><br>
            <b>LookLottery</b><br/>
            <b>樂透查詢，查詢樂透擁有者、樂透集資金、玩家帳號。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>6.</b><br>
            <b>UnlockAccount</b><br/>
            <b>解鎖帳號，解鎖帳號在私有鏈的交易功能。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>7.</b><br>
            <b>ContractStatus</b><br/>
            <b>合約查詢，查詢合約名稱、合約擁有者。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>8.</b><br>
            <b>GiveApprove</b><br/>
            <b>信用交易，提供他人信用額度，預給他方合約代幣。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>9.</b><br>
            <b>TwoPointDeal</b><br/>
            <b>代幣交易，提供地址與地址間的單方代幣給予。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>10.</b><br>
            <b>PutExchange</b><br/>
            <b>交換放置，放置代幣提供交換，並預先扣款額度。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>11.</b><br>
            <b>ExchangeStatus</b><br/>
            <b>交換狀態，變更自方的交易狀態來告知他方交易。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>12.</b><br>
            <b>CancelExchange</b><br/>
            <b>交換取消，取消與他方的交換內容。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>13.</b><br>
            <b>ExchangeItem</b><br/>
            <b>交換代幣，提供雙方同時交換不同額度的代幣。</b>
           </div>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <td>
            <div>
            <b>14.</b><br>
            <b>BuyLottery</b><br/>
            <b>購買樂透，提供地址購買樂透登記。</b>
           </div>
        </td>
    </tr>
</table>
<br>
<br>
