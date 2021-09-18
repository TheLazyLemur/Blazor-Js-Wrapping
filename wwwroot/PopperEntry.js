import "https://unpkg.com/@popperjs/core@2"

export function createPopper (reference, popper, options) {
        if (options != null) {
            Popper.createPopper(reference, popper, options);
        } else {
            Popper.createPopper(reference, popper);
        }
    }
