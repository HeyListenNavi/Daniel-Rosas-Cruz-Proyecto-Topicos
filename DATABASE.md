# Relaciones de Base de Datos

## Tablas
*   **Users** (Usuarios del sistema)
*   **Categories** (Categorías de tareas)
*   **Tasks** (Tareas programadas)
*   **TaskHistory** (Registro de ejecuciones)

## Relaciones
*   **Users** (1) ---- (N) **Categories**
    *   *Clave:* `Categories.UserId` -> `Users.Id`
*   **Users** (1) ---- (N) **Tasks**
    *   *Clave:* `Tasks.UserId` -> `Users.Id`
*   **Categories** (1) ---- (N) **Tasks**
    *   *Clave:* `Tasks.CategoryId` -> `Users.Id`
*   **Tasks** (1) ---- (N) **TaskHistory**
    *   *Clave:* `TaskHistory.TaskId` -> `Tasks.Id`
