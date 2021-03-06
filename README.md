# zfxApi

Oanda APIから最新の為替データを取得して、MongoDBに為替データを保存します。
ASP.NETを用い、Rest APIで参照しやすいように公開します。
DBに登録されている過去のデータを参照することもできます。 

## Oanda API
https://developer.oanda.com/docs/jp/

## 使い方
apsettings.jsonにOandaAPIのAccountIDとTokenを登録

  "OandaAPI": {
    "AccountID": "",
    "Token": "",
    "Environment": "Trade"
  }

  apsettings.jsonにmongoDBの設定を登録

    "MongoDB": {
    "Server": "localhost",
    "Database": "zfx",
    "User": "zfxapi",
    "Password": "password",
    "Port": 27017
  }

## API
サーバ設定、Port設定などはlaunchSettings.jsonで変更できます。

### 現在値リスト取得 USDJPY/EURUSD/EURJPY/GBPJPY
https://localhost:5001/api/price

#### フォーマット
ID,データ取得元,通貨ペア,Bid,Ask,取得時刻
[{"source":"OandaAPI","pair":"GBPUSD","bid":1.3691,"ask":1.36933,"time":"2021-02-02T11:45:18.7442071+09:00"},{"source":"OandaAPI","pair":"GBPJPY","bid":143.659,"ask":143.687,"time":"2021-02-02T11:45:18.7442068+09:00"},{"source":"OandaAPI","pair":"EURJPY","bid":126.768,"ask":126.785,"time":"2021-02-02T11:45:18.7442075+09:00"},{"source":"OandaAPI","pair":"USDJPY","bid":104.922,"ask":104.936,"time":"2021-02-02T11:45:18.7442056+09:00"},{"source":"OandaAPI","pair":"EURUSD","bid":1.20815,"ask":1.20831,"time":"2021-02-02T11:45:18.7442079+09:00"}]

### 現在値取得 USDJPY
https://localhost:5001/api/price/usdjpy

### 現在値取得 EURUSD
https://localhost:5001/api/price/eurusd
### 現在値取得 EURJPY
https://localhost:5001/api/price/eurjpy
### 現在値取得 EURJPY
https://localhost:5001/api/price/eurjpy
### 現在値取得 GBPJPY
https://localhost:5001/api/price/gbpjpy

### 過去データ取得

過去データ取得は以下のフォーマットで取得できます。日付はUTCで文字列でURLエンコードしてください

https://localhost:5001/api/price/[通貨ペア]?time=[日時文字列]

[例]

https://localhost:5001/api/price/USDJPY?time=2020/02/01%2011:22:33




### ログ取得
https://localhost:5001/api/log

