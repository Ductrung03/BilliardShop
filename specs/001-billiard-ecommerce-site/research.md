# Research & Decisions

This document records the decisions made to resolve ambiguities identified in the implementation plan.

## 1. Testing Framework Selection

- **Unknown**: The project currently lacks a testing framework.
- **Task**: Research and select a standard testing framework for .NET.

### Decision: xUnit

- **Rationale**: xUnit is a modern, popular, and highly extensible testing framework for .NET. It is the de facto standard for new projects and is officially supported by Microsoft. Its clean syntax and ability to run tests in parallel make it a good choice for ensuring code quality in this project.
- **Alternatives Considered**:
  - **MSTest**: While the traditional choice, it is often considered more verbose and less flexible than xUnit.
  - **NUnit**: A very capable framework, but xUnit is generally seen as having a more modern design and is more commonly used in new ASP.NET Core projects.
