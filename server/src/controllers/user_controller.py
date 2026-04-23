from fastapi import APIRouter, Depends, HTTPException
from sqlalchemy.orm import Session
from src.database import get_db
from src.schemas.user_schema import UserCreate
from src.services import user_service
from src.utils.response_handler import success_response, error_response

router = APIRouter(prefix="/auth", tags=["Autenticación"])

@router.post("/register", status_code=201)
def register(user: UserCreate, db: Session = Depends(get_db)):
    try:
        result = user_service.create_new_user(db, user)
        return success_response(
            data=result,
            message="Usuario registrado exitosamente",
            status_code=201
        )
    except HTTPException as e:
        return error_response(message=e.detail, status_code=e.status_code)
    except Exception as e:
        return error_response(
            message="Error interno del servidor",
            status_code=500,
            details=str(e)
        )