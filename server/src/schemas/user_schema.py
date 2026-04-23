from pydantic import BaseModel, Field

class UserCreate(BaseModel):
    nombre_usuario: str = Field(..., min_length=3, max_length=50)
    clave_usuario: str = Field(..., min_length=6)

class UserResponse(BaseModel):
    id_usuario: int
    nombre_usuario: str

    class Config:
        from_attributes = True

# Este es el que faltaba y causaba el crash
class UserRegistrationResponse(BaseModel):
    access_token: str
    token_type: str
    user: UserResponse