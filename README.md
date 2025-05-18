# 📦 Obligatorio Programación 3 — *por Nicolás González*

## 🧪 Estado del Proyecto

**Estado:** ✅ *Completado*

## 📌 Descripción del Proyecto

**ObligatorioP3** es una aplicación web desarrollada como parte de un proyecto académico (**actualmente completado**). Su objetivo principal es **gestionar usuarios, agencias y envíos**, permitiendo realizar las siguientes operaciones:

- 🧑‍💼 Alta, edición, eliminación y listado de usuarios con control de roles y acceso.
- 🏢 Gestión completa de agencias: alta, modificación, eliminación y consulta.
- 📦 Administración y seguimiento de envíos (tanto comunes como urgentes), incluyendo generación de tracking y registro de estados.
- ✅ Validación exhaustiva de datos y manejo de excepciones personalizadas para garantizar la integridad y seguridad de la información.

---

## ⚙️ Tecnologías Utilizadas

| Categoría       | Herramientas                                  |
|------------------|-----------------------------------------------|
| **Backend**       | `C# (.NET 8)`, `Entity Framework Core`         |
| **Frontend**      | `HTML`, `CSS`, `Razor Pages`                   |
| **Base de datos** | `SQL Server`                                   |
| **Cliente**       | `jQuery` para validaciones del lado del cliente |

---

## 🚀 Ejemplos de Uso

# 👤 Gestión de Usuarios

## 1. Alta de Usuario

* Accede como Administrador a la sección "Agregar Usuarios".
* Completa el formulario con los datos requeridos (nombre, apellido, email, contraseña).
* Selecciona el rol del usuario (Administrador, Funcionario o Cliente).
* Presiona "Crear" para agregar el nuevo usuario.
* Recibirás una confirmación cuando el usuario sea creado.

## 2. Listado de Usuarios

* Accede como Administrador a "Listar Usuarios".
* Visualiza todos los usuarios activos del sistema.
* La tabla muestra nombre, apellido, email y rol de cada usuario.
* Los usuarios eliminados no aparecen en este listado.

## 3. Modificación de Usuario

* Desde el listado de usuarios, haz clic en "Editar" junto al usuario deseado.
* Actualiza los campos necesarios.
* Presiona "Guardar" para confirmar los cambios.
* Recibirás una confirmación cuando los cambios sean guardados.

## 4. Eliminación de Usuario

* Desde el listado de usuarios, presiona el botón "Eliminar" junto al usuario.
* Confirma la acción en el cuadro de diálogo.
* El usuario será marcado como eliminado y desaparecerá de la lista.

# 📦 Gestión de Envíos

## 1. Alta de Envío

* Accede como Administrador o Funcionario a "Alta Envío".
* Selecciona el cliente desde el menú desplegable.
* Elige el tipo de envío (Común o Urgente).
* Para envíos comunes: selecciona la agencia de destino.
* Para envíos urgentes: ingresa la dirección de entrega.
* Especifica el peso del paquete.
* Presiona "Crear" para registrar el envío.
* El sistema generará automáticamente un número de tracking.

## 2. Listado de Envíos

* Accede como Administrador o Funcionario a "Mostrar Envíos".
* Visualiza todos los envíos registrados en el sistema.
* La tabla muestra información como cliente, tipo, estado y fechas.

## 3. Finalizar Envío

* Desde el listado de envíos, presiona "Finalizar" junto al envío deseado.
* El sistema registrará la fecha de entrega automáticamente.
* El estado del envío cambiará a "Entregado".

## 4. Seguimiento de Envío

* Desde el listado de envíos, presiona "Agregar Seguimiento".
* Ingresa el comentario sobre el estado actual del envío.
* Presiona "Guardar" para registrar el nuevo estado.
* Cada seguimiento queda registrado con la fecha y el empleado que lo realizó.

# 🔒 Autenticación y Seguridad

## 1. Inicio de Sesión

* Accede a la página de login.
* Ingresa tu email y contraseña.
* Solo podrán acceder empleados (Administradores y Funcionarios).
* Los clientes no tienen acceso al sistema de gestión.

## 2. Cierre de Sesión

* Presiona el botón "Cerrar Sesión" en el dashboard.
* Serás redirigido a la página principal.

## 3. Control de Acceso

* Los Administradores tienen acceso a todas las funcionalidades.
* Los Funcionarios pueden gestionar envíos pero no usuarios.
* Todas las acciones son auditadas con fecha y usuario.

# 🏢 Gestión de Agencias

## 1. Consulta de Agencias

* Las agencias están disponibles para selección en el alta de envíos comunes.
* Cada agencia tiene una dirección y coordenadas geográficas asociadas.

# 📊 Reporte y Seguimiento

## 1. Auditoría

* El sistema registra automáticamente todas las acciones importantes.
* Cada operación de alta, modificación o eliminación queda registrada.
* Se almacena la fecha, usuario, acción y detalles relevantes.

---

## 🛠 API REST

La aplicación también cuenta con una **API REST** que expone información detallada sobre los envíos registrados en el sistema. Actualmente, se encuentra disponible un endpoint que permite **consultar un envío específico por su número de tracking**, devolviendo:

- 📦 Información general del envío.
- 👤 Cliente asociado al envío.
- 🧑‍💼 Funcionario que realizó el registro.
- ⚖️ Peso del paquete.
- 🚚 Tipo de envío (Común o Urgente).
- 📅 Fechas relevantes (alta, entrega, seguimiento).
- 📝 Historial completo de seguimientos.

---

## 🧾 Licencia

Este proyecto está distribuido bajo la licencia **MIT**.

---

## 🙌 Agradecimientos

- A mi profesor [**Joaquín Rodríguez**](https://github.com/JQNR) por el apoyo y guía.
- A la **Universidad ORT Uruguay** por brindar el entorno y herramientas de aprendizaje.

---

## 📫 Contacto

¿Preguntas, ideas o sugerencias?

- 📧 **nicogonzalez2000@gmail.com**
- 🐙 **GitHub:** [JasonLocke8](https://github.com/JasonLocke8)

---

⭐ ¡Gracias por visitar este proyecto! ⭐
