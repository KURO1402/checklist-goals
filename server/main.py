from fastapi import FastAPI
from src.database import engine, Base
from src.controllers import user_controller # Importamos el router

app = FastAPI(title="Lista de objetivos")

Base.metadata.create_all(bind=engine)

app.include_router(user_controller.router)

@app.get("/")
def read_root():
    return {"status": "API Funcionando"}