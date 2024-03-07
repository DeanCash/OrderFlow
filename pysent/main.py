import requests

endpoint = r"http://localhost:5016/{}"
endpoint = endpoint.format("api/live")

body = {
    "Id": 4,
    "Made": "2022-01-01",
    "Consumables": [
        
    ],
    "TableCode": "TN04"
}

res = requests.post(endpoint, json=body)

print(f"{res.status_code = }")
print(res)
