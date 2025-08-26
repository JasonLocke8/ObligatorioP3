# 📦 Obligatorio Programación 3 — *por Nicolás González*

## 🧪 Estado del Proyecto
**Estado:** ✅ *Completado*

---

## 📌 Descripción del Proyecto
**ObligatorioP3** es un sistema completo de gestión y seguimiento de envíos, desarrollado como parte de un proyecto académico.  

Este repositorio contiene:  
- Una **aplicación web MVC** para la gestión de usuarios, agencias y envíos (uso interno).  
- Una **API RESTful** con autenticación JWT que expone la información de los envíos y permite a los clientes interactuar con el sistema.  
- **Despliegue en Azure**, siguiendo principios de **Clean Architecture** y **DDD**, utilizando **.NET 8 + EF Core 8**.  

> 🔗 Además del presente repositorio (Gestor + API), existe un **repositorio separado** para el **MVC Cliente**, que consume esta API y brinda una interfaz web a los clientes.

---

## ⚙️ Tecnologías Utilizadas
| Categoría       | Herramientas                                  |
|-----------------|-----------------------------------------------|
| **Backend**     | `C# (.NET 8)` `Entity Framework Core 8` `JWT` |
| **Frontend**    | `Razor Pages` `HTML` `CSS` `jQuery` |
| **Cliente**     | `ASP.NET MVC` con `HttpClient` |
| **Base de datos** | `SQL Server` |
| **DevOps**      | `Azure App Service` `Azure SQL Database` |

---

## 🚀 Funcionalidades

### 👤 Usuarios y Autenticación
- **Login / Logout de empleados y clientes** con validaciones de email/contraseña.  
- **Cambio de contraseña (clientes vía API o MVC Cliente).**  
- **Roles y accesos diferenciados:**
  - **Admin:** acceso total.
  - **Funcionario:** solo gestión de envíos.
  - **Cliente:** acceso vía MVC Cliente consumiendo la API.  

---

### 📦 Gestión de Envíos
- **Alta de envío:**  
  - Selección de cliente.  
  - Tipo **Común (con agencia de destino)** o **Urgente (con dirección de entrega)**.  
  - Registro de peso y generación automática de número de tracking.  
- **Listado de envíos:** muestra cliente, tipo, estado, fechas y seguimientos.  
- **Finalizar envío:** marca como *entregado* y guarda la fecha de entrega.  
- **Seguimiento de envío:** ingreso de comentarios de estado, registrados con fecha y funcionario responsable.  

---


### 📊 Auditoría
- Registro automático de todas las operaciones críticas: usuario, acción, entidad, fecha y observaciones.  

---

### 🌐 API REST (para Clientes)
Funciones disponibles:
1. **Obtener detalles de un envío por número de tracking**  
   Incluye cliente, funcionario, peso, tipo, estado y seguimientos.  
2. **Login / Logout de cliente**  
   Genera token JWT para acceso seguro.  
3. **Cambio de contraseña**  
   Validación de contraseña actual + nueva.  
4. **Listado completo de envíos propios**  
   Ordenados por fecha con detalle de seguimientos.  
5. **Búsqueda de envíos por rango de fechas**  
   Permite filtrar por estado.  
6. **Búsqueda de envíos por comentario en seguimiento**  
   Retorna envíos que incluyan determinada palabra en el historial.  

---

## 📂 Repositorios Relacionados
- **MVC Cliente (interfaz web para clientes, que consume esta API):** [🔗 Ir al repositorio](Falta_URL)

---

## 🧾 Licencia
Este proyecto está distribuido bajo la licencia **MIT**.

---

## 🙌 Agradecimientos
- A mi profesor [**Joaquín Rodríguez**](https://github.com/JQNR) por el apoyo y guía.  
- A la **Universidad ORT Uruguay** por brindar el entorno y herramientas de aprendizaje.  

---

## 📫 Contacto
- 📧 **nicogonzalez2000@gmail.com**  
- 🐙 **GitHub:** [JasonLocke8](https://github.com/JasonLocke8)  

---

⭐ ¡Gracias por visitar este proyecto! ⭐
