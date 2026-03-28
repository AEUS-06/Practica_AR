# AR Turbo Garage

Proyecto de práctica para la **Unidad 2: Desarrollo de Aplicaciones de Realidad Aumentada Móvil**.

AR Turbo Garage es una experiencia de entretenimiento en realidad aumentada donde el usuario detecta superficies reales, coloca un carrito 3D en el entorno, personaliza su apariencia con imágenes y lo controla mediante interacción táctil.

---

## Tabla de contenido

- [Descripción general](#descripción-general)
- [Objetivo de la práctica](#objetivo-de-la-práctica)
- [Competencias desarrolladas](#competencias-desarrolladas)
- [Temario relacionado](#temario-relacionado)
- [Características funcionales](#características-funcionales)
- [Tecnologías utilizadas](#tecnologías-utilizadas)
- [Plataforma objetivo](#plataforma-objetivo)
- [Estructura del proyecto](#estructura-del-proyecto)
- [Requisitos previos](#requisitos-previos)
- [Instalación y ejecución](#instalación-y-ejecución)
- [Roadmap de desarrollo](#roadmap-de-desarrollo)
- [Pruebas y optimización](#pruebas-y-optimización)
- [Resultados de aprendizaje esperados](#resultados-de-aprendizaje-esperados)
- [Autoría](#autoría)

---

## Descripción general

La aplicación está orientada a dispositivos móviles Android con soporte ARCore. El flujo principal de uso es:

1. Detectar planos del entorno (mesa o piso)
2. Colocar un carrito 3D en una superficie válida
3. Personalizar su apariencia con diseños basados en imagen
4. Controlar el movimiento mediante UI táctil
5. Evaluar desempeño para garantizar experiencia fluida

---

## Objetivo de la práctica

Desarrollar una aplicación móvil de realidad aumentada utilizando **Unity 6, AR Foundation y ARCore**, integrando detección de planos, seguimiento de imágenes, controles de interacción y optimización para dispositivos móviles.

---

## Competencias desarrolladas

- Configuración de plataformas de desarrollo para RA móvil
- Creación de experiencias de RA en dispositivos móviles
- Detección de marcadores y seguimiento de objetos
- Diseño de interacción y experiencia de usuario
- Pruebas, profiling y optimización de rendimiento

---

## Temario relacionado

### Unidad 2. Desarrollo de Aplicaciones de Realidad Aumentada Móvil

- 2.1 Plataformas de desarrollo para RA móvil
- 2.2 Creación de experiencias de RA en dispositivos móviles
- 2.3 Detección de marcadores y seguimiento de objetos
- 2.4 Interacción y experiencia de usuario en RA móvil
- 2.5 Pruebas y optimización de aplicaciones de RA

---

## Características funcionales

La aplicación permite:

1. Detectar superficies en el entorno
2. Colocar un carrito 3D sobre una mesa o piso
3. Personalizar la apariencia del vehículo
4. Utilizar una imagen como marcador para cargar diseños
5. Controlar el movimiento del carrito mediante UI táctil
6. Evaluar rendimiento y optimización en Android

---

## Tecnologías utilizadas

- Unity 6
- AR Foundation
- ARCore
- XR Plugin Management
- C#
- Git y GitHub

---

## Plataforma objetivo

- Sistema operativo: Android
- Framework de RA: ARCore
- API mínima: 24+
- Arquitectura recomendada: ARM64

---

## Estructura del proyecto

```text
Assets/
Packages/
ProjectSettings/
Library/
Logs/
Temp/
UserSettings/
Assembly-CSharp.csproj
Practica_AR.slnx
readme.md
```

---

## Requisitos previos

Antes de compilar o ejecutar el proyecto, asegúrate de contar con:

- Unity Hub instalado
- Unity 6 (misma versión del proyecto)
- Módulo de Android Build Support
- SDK y NDK de Android configurados desde Unity Hub
- Dispositivo Android compatible con ARCore
- Depuración USB habilitada en el dispositivo

---

## Instalación y ejecución

1. Clona este repositorio:

```bash
git clone <URL_DEL_REPOSITORIO>
```

2. Abre el proyecto desde Unity Hub.
3. Espera la importación inicial de paquetes y assets.
4. Verifica en Package Manager que AR Foundation y ARCore XR Plugin estén instalados.
5. En Build Settings, selecciona Android como plataforma activa.
6. Conecta un dispositivo físico compatible y ejecuta Build And Run.

---

## Roadmap de desarrollo

### Fase 1
Base AR y detección de planos.

### Fase 2
Colocación del carrito en superficie.

### Fase 3
Personalización mediante image tracking.

### Fase 4
Controles e interfaz de usuario.

### Fase 5
Pruebas y optimización.

---

## Pruebas y optimización

Para la validación final del proyecto se consideran:

- Estabilidad de tracking en distintas condiciones de luz
- Precisión en detección de planos
- Fluidez del renderizado (objetivo recomendado: 30-60 FPS)
- Tiempo de respuesta de controles táctiles
- Consumo de batería y temperatura del dispositivo

Herramientas sugeridas:

- Unity Profiler
- Frame Debugger
- Estadísticas en tiempo real del Game View
- Pruebas en varios dispositivos Android

---

## Resultados de aprendizaje esperados

Al finalizar esta práctica se espera que el estudiante pueda:

- Implementar una experiencia básica de RA móvil funcional
- Integrar detección de planos e image tracking en un mismo flujo
- Diseñar interacción táctil orientada a usabilidad
- Aplicar mejoras de rendimiento para despliegue en Android
