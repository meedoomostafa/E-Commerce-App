// Show loading spinner during page transitions
document.addEventListener('DOMContentLoaded', function () {
    const links = document.querySelectorAll('a:not([href^="#"])');
    const spinner = document.querySelector('.loading-spinner');

    links.forEach(link => {
        link.addEventListener('click', function (e) {
            // Skip for links that open in new tabs or are logout links
            if (link.getAttribute('target') === '_blank' || link.href.includes('Logout')) return;

            e.preventDefault();
            spinner.style.display = 'block';
            setTimeout(() => {
                window.location.href = link.href;
            }, 500); // Simulate a delay for the spinner
        });
    });
});

// Smooth scroll for anchor links
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({ behavior: 'smooth' });
        }
    });
});