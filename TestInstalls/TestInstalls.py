

from __future__ import annotations

import importlib


REQUIRED_IMPORTS: dict[str, str] = {
    "numpy": "numpy",
    "pandas": "pandas",
    "matplotlib": "matplotlib",
    "scikit-learn": "sklearn",
    "torch": "torch",
    "torchvision": "torchvision",
}


def assert_required_packages(required_imports: dict[str, str] = REQUIRED_IMPORTS) -> None:
    
    # TODO:
    # 1) Try importing each module in required_imports.values()
    # 2) Collect any that fail
    # 3) assert that none are missing (print a helpful message)
    missing = []

    for friendly_name, import_name in required_imports.items():
        try:
            importlib.import_module(import_name)
        except Exception:
            missing.append(friendly_name)

    if missing:
        missing_list = ", ".join(missing)
        raise AssertionError(
            f"The following required packages are missing or cannot be imported: {missing_list}"
        )



def main() -> None:
    assert_required_packages()
    print("All required packages are installed and importable.")


if __name__ == "__main__":
    main()

