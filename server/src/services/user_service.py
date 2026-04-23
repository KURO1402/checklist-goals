from sqlalchemy.orm import Session
from src.models.user import User
from src.schemas.user_schema import UserCreate
from src.services.auth_service import AuthService
from fastapi import HTTPException

def create_new_user(db: Session, user_data: UserCreate):
    user_exists = db.query(User).filter(
        User.nombre_usuario == user_data.nombre_usuario
    ).first()

    if user_exists:
        raise HTTPException(
            status_code=400,
            detail="Este nombre de usuario ya está en uso"
        )

    hashed_pwd = AuthService.hash_password(user_data.clave_usuario)
    new_user = User(
        nombre_usuario=user_data.nombre_usuario,
        clave_usuario=hashed_pwd
    )

    db.add(new_user)
    db.commit()
    db.refresh(new_user)

    token = AuthService.create_access_token(data={"sub": new_user.nombre_usuario})

    return {
        "access_token": token,
        "token_type": "bearer",
        "user": {
            "id_usuario": new_user.id_usuario,
            "nombre_usuario": new_user.nombre_usuario
        }
    }