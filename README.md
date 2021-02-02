# zfxApi

Oanda APIから最新の為替データを取得して、MongoDBに為替データを保存します。
ASP.NETを用い、Rest APIで参照しやすいように公開します。過去のデータ取得APIも作成予定。

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
  
### 現在値リスト取得 USDJPY/EURUSD/EURJPY/GBPJPY
https://localhost:5001/api/price

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

### ログ取得
https://localhost:5001/api/log
  
