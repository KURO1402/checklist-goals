from passlib.context import CryptContext
from jose import JWTError, jwt
from datetime import datetime, timedelta, timezone
import os

# Configuramos el algoritmo de hashing (bcrypt es el estándar de la industria)
pwd_context = CryptContext(schemes=["bcrypt"], deprecated="auto")

# Configuración de JWT (Esto debería ir en tu .env)
SECRET_KEY = os.getenv("SECRET_KEY", "una_llave_muy_secreta_123")
ALGORITHM = "HS256"
ACCESS_TOKEN_EXPIRE_MINUTES = 30

class AuthService:
    @staticmethod
    def hash_password(password: str) -> str:
        """Convierte texto plano en un hash irreversible."""
        return pwd_context.hash(password)

    @staticmethod
    def verify_password(plain_password: str, hashed_password: str) -> bool:
        """Compara la clave ingresada con el hash de la base de datos."""
        return pwd_context.verify(plain_password, hashed_password)

    @staticmethod
    def create_access_token(data: dict):
        """Genera el 'boleto' (JWT) para que el usuario navegue por la API."""
        to_encode = data.copy()
        expire = datetime.now(timezone.utc) + timedelta(minutes=ACCESS_TOKEN_EXPIRE_MINUTES)
        to_encode.update({"exp": expire})
        # El JWT contiene los datos del usuario (como su ID) firmados por nosotros
        return jwt.encode(to_encode, SECRET_KEY, algorithm=ALGORITHM)