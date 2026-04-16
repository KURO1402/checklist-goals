from fastapi import FastAPI
from src.database import engine, Base

app = FastAPI(title="Mi API con Postgres")

Base.metadata.create_all(bind=engine)

@app.get("/")
def read_root():
    return {"status": "Conectado a la base de datos con éxito"}