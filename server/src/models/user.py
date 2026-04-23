from src.database import Base
from sqlalchemy import Column, Integer, String

class User(Base):
    __tablename__ = "usuarios"

    id_usuario = Column(Integer, primary_key=True, index=True)
    nombre_usuario = Column(String(50), unique=True, nullable=False)
    clave_usuario = Column(String(255), nullable=False)