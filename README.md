# HigherLogics.Web.Windmill

This is an experimental library that provides a simpler interface to using the excellent Windmill dashboard UI:

https://github.com/estevanmaito/windmill-dashboard

Getting used to and remembering all of the atomic styles to apply to various elements and how the
HTML should be structured can hard, especially if you're new to atomic CSS and tailwind, so this
library provides tag helpers that apply the base styles to the basic elements, and provide
elements that are hopefully easier to remember and use.

For instance, if you want an inset icon on your input, instead of remembering all of this markup:

    <label class="block text-sm">
    <span class="text-gray-700 dark:text-gray-400">Icon left</span>
    <div class="relative text-gray-500 focus-within:text-purple-600 dark:focus-within:text-purple-400">
        <input
        class="block w-full pl-10 mt-1 text-sm text-black dark:text-gray-300 dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:focus:shadow-outline-gray form-input" placeholder="Jane Doe" />
        <div class="absolute inset-y-0 flex items-center ml-3 pointer-events-none">
        <svg
            class="w-5 h-5"
            aria-hidden="true"
            fill="none"
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            viewBox="0 0 24 24"
            stroke="currentColor">
            <path d="M3 8l7.89 5.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"></path>
        </svg>
        </div>
    </div>
    </label>

You can instead write this simpler markup:

    <windmill-label text="Icon left" class="block">
        <windmill-input-group group-type="Icon">
            <windmill-input-icon layout="Left">
                <svg class="w-5 h-5"
                    aria-hidden="true"
                    fill="none"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    viewBox="0 0 24 24"
                    stroke="currentColor">
                    <path d="M3 8l7.89 5.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"></path>
                </svg>
            </windmill-input-icon>
            <windmill-input placeholder="Jane Doe" class="pl-10 text-black mt-1" />
        </windmill-input-group>
    </windmill-label>

I'm not sure if this is the best way to accomplish this, so this is a bit of an experiment.

# Future Work

 * The default colours are currently hard-coded into the basic styling, but I'd like to remove those and make them parameters.