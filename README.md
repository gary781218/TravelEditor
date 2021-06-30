# WinForm 旅遊行程編輯器

這是筆者第一個完成的專案, 是使用winform完成的, database以csv字串組合的方法實作, 景點相關資訊是串接Google Map的API取得，包含景點名稱、星星數、地址等資訊。

將使用者介面依功能分為三個大方向做設計

- 景點查詢及儲存
- 資料庫查詢
- 旅程編輯

</br>

## 事前準備

為節省上傳檔案的容量，我並未將package上傳，使用者可自行至nuget安裝下列套件

- [gmaps-api-net](https://github.com/ericnewton76/gmaps-api-net)
- [CefSharp](https://www.nuget.org/packages/CefSharp.WinForms/)
- [GMap.NET.WinForms](https://www.nuget.org/packages/GMap.NET.WinForms/)
- [申請Google API 金鑰](https://dotblogs.com.tw/supergary/2020/07/07/gmpapi)

</br>

## 景點查詢與儲存

因為使用tabControl作分頁，故主程式碼一樣是**Index_AddPoint_Form.cs**

</br>

#### 程式邏輯如下

1. 在input內輸入關鍵字, 按下搜尋
2. 使用**GMap.NET.WinForms**進行一系列的認證與查詢
3. 依查詢結果筆數顯示於畫面
4. 對單一景點，點擊顯示地圖, 使用CefSharp顯示Google Map
5. 對單一景點，點擊加入資料庫，使用FileStream將景點資料寫入CSV

![image](https://user-images.githubusercontent.com/49896529/123939492-c2d08a00-d9ca-11eb-82b1-bb9cfbcc589b.png)

</br>

## 資料庫查詢

主程式碼為**Index_AddPoint_Form.cs**, 相關的儲存路徑寫在**App.config**, 使用者須自行更改路徑.

</br>

#### 亮點

1. 可依需求對資料庫作篩選, 如縣市、區域等, 也可對畫面作欄位顯示設定
2. 可對資料庫部分資料進行更新, 或刪除
3. 可新增圖片, 及顯示圖片

![image](https://user-images.githubusercontent.com/49896529/123942017-52773800-d9cd-11eb-9124-a6bb9bb60c0e.png)

</br>

## 旅遊行程編輯

主程式碼為**Index_AddPoint_Form.cs**, 相關的儲存路徑寫在**App.config**, 使用者須自行更改路徑.

</br>

#### 亮點

1. 可依照不同次的計畫分別建立專案
2. 使用route API取得交通路線、距離、預估時間. 若使用者兩景點間, 時間差小於交通時間, 會以紅色的字體顯示提醒.
3. 可新增圖片, 及顯示圖片

![image](https://user-images.githubusercontent.com/49896529/123942734-04166900-d9ce-11eb-8465-b99555c9ee90.png)

</br>

#### 相關技術網誌

- [功能塊1](https://dotblogs.com.tw/supergary/2020/09/03/project1_1)
- [功能塊2](https://dotblogs.com.tw/supergary/2020/09/07/project1_2)
- [功能塊3](https://dotblogs.com.tw/supergary/2021/01/14/project1_3)
