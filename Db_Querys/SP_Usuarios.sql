use ProyectoEditorial
GO

CREATE proc sp_RegistrarUsuario(
    @usuario varchar(50),
    @pass varchar(500),
    @mail varchar(100),
    @admin bit,
    @Registrado bit OUTPUT,
    @Mensaje varchar(100) OUTPUT
)
as 
BEGIN

    if(not exists(select * from Usuario where Mail = @mail))
    begin
        insert into Usuario(NombreUsuario, Contraseña, Mail, EsAdmin)output INSERTED.ID_Usuario values(@usuario, @pass, @mail, @admin)
        set @Registrado = 1
        set @Mensaje = 'Usuario registrado'
    end 
    ELSE
    begin 
        set @Registrado = 0
        set @Mensaje = 'Correo ya existente'
    end 
end